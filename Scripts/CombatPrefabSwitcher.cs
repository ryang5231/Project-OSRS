using UnityEngine;
using System.Collections;

public class CombatPrefabSwitcher : MonoBehaviour
{
    public GameObject[] prefabs; // Array of prefabs to switch between
    public float attackDuration = 1.0f; // Duration of attack action in seconds
    public float blockDuration = 1.0f; // Duration of block action in seconds
    public float deathDuration = 1.0f;
    public float idleDuration = 1.0f;
    public Transform povCamera;
    public int hitPoints = 3;
    public AudioClip[] ouchSounds;
    public AudioClip[] hitSounds;
    public AudioClip deathSound;
    public GameObject deathSpawn;

    private Vector3 previousPosition;
    private bool isInCombat = false; // Flag to track if the NPC is in combat
    private float actionTimer = 0.0f; // Timer for tracking action duration
    private int currentPrefabIndex = 0; // Index of the current active prefab
    private WanderAi wanderAiScript; // Reference to the WanderAi script

    void Start()
    {
        // Initialize previousPosition with the initial position of the parent GameObject
        previousPosition = transform.position;
        // Disable all prefabs except the first one (idle)
        prefabs[0].SetActive(true);
        for (int i = 1; i < prefabs.Length; i++)
        {
            prefabs[i].SetActive(false);
        }
        wanderAiScript = GetComponent<WanderAi>();
        // Subscribe to the OnEnterCombat event
        GetComponent<CombatTrigger>().inCombat += HandleEnterCombat;
    }

    // Method to handle entering combat
    private void HandleEnterCombat(bool inCombat)
    {
        isInCombat = inCombat;

        if (isInCombat)
        {
            wanderAiScript.EnterCombat();
            // Unsubscribe from the event after the first invocation
            GetComponent<CombatTrigger>().inCombat -= HandleEnterCombat;
            Vector3 cameraPosition = povCamera.position;
            actionTimer = blockDuration;
            SwitchPrefab(3);
            int randomIndex = Random.Range(0, hitSounds.Length);
            AudioManager.instance.PlayHitSound(hitSounds[randomIndex]);
            transform.LookAt(cameraPosition);
        }
    }

    void Update()
    {
        // If in combat, decrement action timer
        if (isInCombat && hitPoints > 0)
        {
            actionTimer -= Time.deltaTime;

            if (actionTimer <= 0.0f && currentPrefabIndex != 0 && hitPoints > 0)
            {
                // Debug.Log("back to idle after atk/block");
                gameObject.GetComponent<Animator>().Play("Idle");
                SwitchPrefab(0); // Switch to idle prefab
                actionTimer = idleDuration;
            }
            else if (actionTimer <= 0.0f && hitPoints > 0)
            {
                // Debug.Log("atacking");
                SwitchPrefab(2);
                int randomIndex = Random.Range(0, ouchSounds.Length);
                AudioManager.instance.PlayOuchSound(ouchSounds[randomIndex]);
                actionTimer = attackDuration;
            }
        }
        else
        {
            // Check if the position of the parent GameObject has changed
            // transform.position != previousPosition
            // wanderAiScript != null && wanderAiScript.isWandering
            if (transform.position != previousPosition && hitPoints > 0)
            {
                // Parent GameObject is moving
                // Debug.Log("Walkinf");
                SwitchPrefab(1);
            }
            // wanderAiScript != null && !wanderAiScript.isWandering && 
            else if (hitPoints > 0)
            {
                // Debug.Log("stationary after move");
                // Parent GameObject is not moving
                SwitchPrefab(0);
            }

            // Update previousPosition for the next frame
            previousPosition = transform.position;
        }
    }

    // Method to switch to a specific prefab
    private void SwitchPrefab(int prefabIndex)
    {
        prefabs[currentPrefabIndex].SetActive(false);
        prefabs[prefabIndex].SetActive(true);
        currentPrefabIndex = prefabIndex;
    }

    // OnTriggerEnter is called when another collider enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is an axe
        if (other.CompareTag("Iron Dagger") || other.CompareTag("Rune Scim") || other.CompareTag("Fang"))
        {
            HandleBlockTrigger(other);
        }
    }

    private void HandleBlockTrigger(Collider other)
    {
        if (other.CompareTag("Iron Dagger") || other.CompareTag("Rune Scim") || other.CompareTag("Fang"))
        {
            // Debug.Log("blocking subseq hits");
            SwitchPrefab(3);
            int randomIndex = Random.Range(0, hitSounds.Length);
            AudioManager.instance.PlayHitSound(hitSounds[randomIndex]);
            actionTimer = blockDuration;
            if (other.CompareTag("Iron Dagger"))
            {
                hitPoints--;
            }
            else if (other.CompareTag("Rune Scim"))
            {
                hitPoints -= 3;
            }
            else if (other.CompareTag("Fang"))
            {
                hitPoints -= 6;
            }
            

            if (hitPoints <= 0)
            {
                // Debug.Log("dieded");
                for (int i = 0; i < prefabs.Length - 1; i++)
                {
                    // Debug.Log("prefab " + i + " disabled");
                    prefabs[i].SetActive(false);
                }
                // Play death animation and schedule destruction
                HandleDeath();
            }
        }
    }

    
    private void HandleDeath()
    {
        // Debug.Log("playing death anima");
        isInCombat = false;
        SwitchPrefab(4); // Play death animation
        AudioManager.instance.PlayDeathSound(deathSound);
        StartCoroutine(DestroyAfterAnimation(deathDuration)); // Delay destruction
    }

    private IEnumerator DestroyAfterAnimation(float delay)
    {
        // yield return new WaitForSeconds(delay);
        float elapsedTime = 0.0f;

    while (elapsedTime < delay)
    {
        // Debug.Log("Time remaining until destroyed: " + (delay - elapsedTime) + " seconds");
        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        elapsedTime += 1.0f; // Increment elapsed time by 1 second
    }

    // Debug.Log("Animation supposedly finished after " + delay + " seconds");

        for (int i = 0; i < prefabs.Length; i++)
        {
            Destroy(prefabs[i]);
        }

        // Instantiate deathSpawn with a slightly higher Y coordinate
        Vector3 deathSpawnPosition = transform.position;
        deathSpawnPosition.y += 6.0f; // Adjust the Y coordinate as needed
        Instantiate(deathSpawn, deathSpawnPosition, Quaternion.identity);

        Destroy(gameObject);
    }
}

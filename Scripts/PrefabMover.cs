using UnityEngine;
using System.Collections;

public class PrefabMover : MonoBehaviour
{
    public Transform prefab; // Reference to the prefab you want to move
    public GameObject groundMesh; // Reference to the ground mesh GameObject
    public float moveSpeed = 2f; // Speed at which the prefab moves
    public float minMoveDistance = 2f; // Minimum move distance
    public float minInterval = 1f; // Minimum time interval between movements
    public float maxInterval = 3f; // Maximum time interval between movements

    private Vector3 targetPosition;

    void Start()
    {
        // Start moving the prefab
        StartCoroutine(MovePrefab());
    }

    IEnumerator MovePrefab()
    {
        while (true)
        {
            // Generate a random target position within the boundary and minimum move distance
            targetPosition = GetRandomGroundPosition();

            // Calculate the distance to the target position
            float distance = Vector3.Distance(prefab.position, targetPosition);

            // If the distance is less than the minimum move distance, continue generating a new random position
            while (distance < minMoveDistance)
            {
                targetPosition = GetRandomGroundPosition();
                distance = Vector3.Distance(prefab.position, targetPosition);
            }

            // Calculate the time it takes to reach the target position based on the move speed
            float duration = distance / moveSpeed;

            // Move the prefab to the target position over the calculated duration
            while (duration > 0)
            {
                prefab.position = Vector3.MoveTowards(prefab.position, targetPosition, moveSpeed * Time.deltaTime);
                duration -= Time.deltaTime;
                yield return null;
            }

            // Wait for a random interval before moving again
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }
    }

    Vector3 GetRandomGroundPosition()
    {
        RaycastHit hit;
        Vector3 randomPoint = Vector3.zero;

        // Cast a ray downward from a random position above the ground mesh
        if (Physics.Raycast(new Vector3(Random.Range(groundMesh.transform.position.x - 5f, groundMesh.transform.position.x + 5f), 
                                         10f, 
                                         Random.Range(groundMesh.transform.position.z - 5f, groundMesh.transform.position.z + 5f)), 
                            Vector3.down, out hit, Mathf.Infinity))
        {
            randomPoint = hit.point;
        }

        // Ensure the random point is on the horizontal plane (X and Z axes)
        randomPoint.y = prefab.position.y; // Keep the same height as the prefab

        return randomPoint;
    }
}

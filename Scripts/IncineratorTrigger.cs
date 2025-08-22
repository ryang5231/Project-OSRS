using UnityEngine;

public class IncineratorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is a burnable object
        if (other.CompareTag("Burnable"))
        {
            // Play destruction sound
            AudioManager.instance.PlayDestructionSound();

            // Destroy the entering object
            Destroy(other.gameObject);
        }
    }
}

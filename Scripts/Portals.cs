using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Portals : MonoBehaviour
{
    public Transform destination; // The destination transform where you want to teleport the player
    OVRPlayerController playerController;
    GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("MainCamera"))
        {
            Player = other.gameObject;
            TeleportPlayer(Player);
        }
    }

    // Method to teleport the player to the destination
    private void TeleportPlayer(GameObject player)
    {
        // Check if the destination is not null
        if (destination != null)
        {
            // Get the OVRPlayerController component attached to the player
            playerController = player.GetComponent<OVRPlayerController>();

            // Check if the player controller is found
            if (playerController != null)
            {
                StartCoroutine("Teleport");
            }
            else
            {
                Debug.LogWarning("OVRPlayerController not found on the player GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("Destination transform is not assigned.");
        }
    }

    IEnumerator Teleport()
    {

        playerController.enabled = false; 
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = destination.position;
        yield return new WaitForSeconds(0.1f);
        playerController.enabled = true;
    }
}

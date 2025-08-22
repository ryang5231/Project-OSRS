using UnityEngine;

public class PrefabSwitcher : MonoBehaviour
{
    public Transform vrCamera; // Reference to the VR camera
    public GameObject[] prefabs; // Array of prefabs to switch between
    private Vector3 previousCameraPosition; // Previous position of the camera

    void Start()
    {
        // Initialize previousCameraPosition with the initial position of the camera
        previousCameraPosition = vrCamera.position;
        Debug.Log($"original position: {previousCameraPosition}");

        // Disable all prefabs except the first one
        for (int i = 1; i < prefabs.Length; i++)
        {
            prefabs[i].SetActive(false);
        }
    }

    void Update()
    {
        // Check if the camera position has changed
        if (vrCamera.position != previousCameraPosition)
        {
            // Character is moving
            prefabs[0].SetActive(false);
            prefabs[1].SetActive(true);
            previousCameraPosition = vrCamera.position; // Update previous position
        }
        else
        {
            prefabs[1].SetActive(false);
            prefabs[0].SetActive(true);
        }
    }

}

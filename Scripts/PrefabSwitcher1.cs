using UnityEngine;
using System.Collections;

public class PrefabSwitcher1 : MonoBehaviour
{
    public GameObject[] prefabs; // Array of prefabs to switch between
    private Vector3 previousPosition; // Previous position of the parent GameObject

    void Start()
    {
        // Initialize previousPosition with the initial position of the parent GameObject
        previousPosition = transform.position;

        // Disable all prefabs except the first one
        for (int i = 1; i < prefabs.Length; i++)
        {
            prefabs[i].SetActive(false);
        }
    }

    void Update()
    {
        // Check if the position of the parent GameObject has changed
        if (transform.position != previousPosition)
        {
            // Parent GameObject is moving
            prefabs[0].SetActive(false);
            prefabs[1].SetActive(true);
        }
        else
        {
            // Parent GameObject is not moving
            prefabs[1].SetActive(false);
            prefabs[0].SetActive(true);
        }

        // Update previousPosition for the next frame
        previousPosition = transform.position;
    }
}

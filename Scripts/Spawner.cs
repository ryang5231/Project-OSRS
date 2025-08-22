using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToInstantiate; // Reference to the prefab you want to instantiate
    private bool isSpawned = false;

    void Update()
    {
        if (!isSpawned)
        {
            // Instantiate the prefab
            GameObject instantiatedPrefab = prefabToInstantiate;

            // Ensure that the instantiated object has a Rigidbody component
            Rigidbody rb = instantiatedPrefab.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.Log("no rigid");
                rb = instantiatedPrefab.AddComponent<Rigidbody>();
            }

            // Ensure that the instantiated object has a Collider component
            Collider col = instantiatedPrefab.GetComponent<Collider>();
            if (col == null)
            {
                Debug.Log("no collider");
                col = instantiatedPrefab.AddComponent<MeshCollider>(); // You can replace MeshCollider with the appropriate collider type
            }
            Instantiate(instantiatedPrefab, transform.position, Quaternion.identity);
            isSpawned = true;
        }
    }
}

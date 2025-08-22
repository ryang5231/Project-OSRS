using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSpawnLog : MonoBehaviour
{
    public GameObject spawnLog;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnLog, transform.position, Quaternion.identity);
    }
}

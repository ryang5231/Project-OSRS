using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 24;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

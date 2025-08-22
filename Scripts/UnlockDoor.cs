using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject toDestroy;
    public bool requiresDragonKey;
    void OnTriggerEnter(Collider other){
        if ((other.CompareTag("Giant Key") && !requiresDragonKey) || (other.CompareTag("Dragon Key") && requiresDragonKey))
        {
            AudioManager.instance.PlayUnlockSound();
            Destroy(toDestroy);
        }
    }
}

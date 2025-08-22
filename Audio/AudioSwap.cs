using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public AudioClip newTrack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            AudioManager.instance.SwapTrack(newTrack);
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("MainCamera"))
        {
            AudioManager.instance.ReturnToDefault();
        }
    }
}

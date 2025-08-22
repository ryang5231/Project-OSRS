using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    public event Action<bool> inCombat;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Iron Dagger") || other.CompareTag("Rune Scim") || other.CompareTag("Fang"))
        {
            // Trigger the event to notify other scripts
            inCombat?.Invoke(true);
        }
    }
}

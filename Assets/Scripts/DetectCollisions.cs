using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Caja"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject); 
        }
    }
}

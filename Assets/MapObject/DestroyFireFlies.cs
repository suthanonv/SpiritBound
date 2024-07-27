using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireFlies : MonoBehaviour
{
    [SerializeField] GameObject fireFlies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(fireFlies);
        }
    }

}

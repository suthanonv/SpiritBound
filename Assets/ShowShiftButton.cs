using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowShiftButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TutorialManager.instance.ShowSpaceButton();
            Destroy(gameObject);
        }
    }

}

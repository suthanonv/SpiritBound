using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowFButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TutorialManager.instance.ShowFButton();
            Destroy(gameObject);
        }
    }

}

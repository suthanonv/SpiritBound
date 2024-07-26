using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.Instance.CoinCollected();
            CoinsUI.instance.UpdateCoinsText();
            //Debug.Log("Collect");
            Destroy(gameObject);
        }
    }
}

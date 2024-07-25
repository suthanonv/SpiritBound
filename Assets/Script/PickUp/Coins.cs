using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("kuy");
            PlayerInventory.Instance.CoinCollected();
            CoinsUI.instance.UpdateCoinsText();
            Debug.Log("kuy2");
            Destroy(gameObject);
        }
    }
}

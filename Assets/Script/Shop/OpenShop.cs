using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject shop;
    public GameObject E;
    public bool inShopRange = false;
    public bool inShop = false;

    public void Start()
    {
        shop = GameObject.Find("ShopPanel");
        shop.SetActive(false);
        E.SetActive(false);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            E.SetActive(true);
            inShopRange = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            E.SetActive(false);
            inShopRange = false;
        }
    }
    private void Update()
    {
        if (inShop == false && inShopRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(1);
                shop.SetActive(true);
                inShop = true;
            }
        }
        if (inShop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                shop.SetActive(false);
                inShop = false;
            }
        }
    }
    private void openShop()
    {
        shop.SetActive(true);
    }
}

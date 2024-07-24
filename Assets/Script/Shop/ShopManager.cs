using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI;
    public GameObject shopType1;
    public GameObject shopType2;
    public GameObject shopType3;

    public void Start()
    {
        coinsUI.text = "Coins : " + coins.ToString();
        openShopType1();
    }
    public void AddCoins()
    {
        coins++;
        coinsUI.text = "Coins : " + coins.ToString();
    }
    public void openShopType1()
    {
        shopType1.SetActive(true);
        shopType2.SetActive(false);
        shopType3.SetActive(false);
    }
    public void openShopType2()
    {
        shopType1.SetActive(false);
        shopType2.SetActive(true);
        shopType3.SetActive(false);
    }
    public void openShopType3()
    {
        shopType1.SetActive(false);
        shopType2.SetActive(false);
        shopType3.SetActive(true);
    }

}

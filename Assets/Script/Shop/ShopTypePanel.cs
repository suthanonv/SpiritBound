using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTypePanel : MonoBehaviour
{
    public ShopItemSO[] shopItemSO;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO;
    public Button[] purchaseButton;
    public ShopManager shopManager;

    public void Start()
    {
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        LoadPanel();
        CheckPurchasable();
    }
    public void Update()
    {
        CheckPurchasable();
    }
    public void LoadPanel()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemSO[i].description;
            shopPanels[i].costTxt.text = "Price : " + shopItemSO[i].baseCost.ToString();
        }
    }
    public void CheckPurchasable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (shopManager.coins >= shopItemSO[i].baseCost)
            {
                purchaseButton[i].interactable = true;
            }
            else
            {
                purchaseButton[i].interactable = false;
            }
        }
    }
    public void buyItem(int buttonNo)
    {
        if (shopManager.coins >= shopItemSO[buttonNo].baseCost)
        {
            shopManager.coins = shopManager.coins - shopItemSO[buttonNo].baseCost;
            shopManager.coinsUI.text = "Coins : " + shopManager.coins.ToString();
            CheckPurchasable();
        }
    }
}

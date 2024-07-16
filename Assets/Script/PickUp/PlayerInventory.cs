using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int maxPotions = 3;
    private int currentPotions = 0;

    public int NumberOfCoins = 0;
    public UnityEvent OnCoinsCollected; // UnityEvent to notify when coins are collected

    public static PlayerInventory Instance;

    private void Awake()
    {
        Instance = this;

        if (OnCoinsCollected == null)
        {
            OnCoinsCollected = new UnityEvent();
        }
    }

    private void Start()
    {
        // Initialize the coin UI with the current coin count
        CoinsUI coinsUI = FindObjectOfType<CoinsUI>();
        if (coinsUI != null)
        {
            OnCoinsCollected.AddListener(coinsUI.UpdateCoinsText);
            coinsUI.UpdateCoinsText();
        }
    }

    public void AddPotion()
    {
        if (currentPotions < maxPotions)
        {
            currentPotions++;
            Debug.Log("Potion +1 : " + currentPotions);
            // Update the potion UI if you have one
        }
        else
        {
            Debug.Log("Cannot carry any more potions.");
        }
    }

    public void UsePotion()
    {
        if (currentPotions > 0)
        {
            currentPotions--;
            Debug.Log("Potion used. Remaining potions: " + currentPotions);
            // Update the potion UI if you have one
        }
        else
        {
            Debug.Log("No potions left.");
        }
    }

    public int GetCurrentPotionCount()
    {
        return currentPotions;
    }

    public void CoinCollected()
    {
        NumberOfCoins++;
        OnCoinsCollected.Invoke(); // Invoke the event without parameters
    }
}

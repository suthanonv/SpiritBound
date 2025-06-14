using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int maxPotions = 3;
    private int currentPotions = 0;

    public int NumberOfCoins = 0;
    [SerializeField] UnityEvent OnCoinsCollected;

    public static PlayerInventory Instance;

    [SerializeField] float HealignAmount;
   
    private void Awake()
    {
        
        Instance = this;
    }



    [Header("Use Potion Key")]
    [SerializeField] KeyCode Health = KeyCode.F;


    private void Update()
    {
        if(Input.GetKeyDown(Health) && currentPotions > 0)
        {
            UsePotion();
            FindObjectOfType<PotionUIManager>().UpdatePotionUI();
        }
    }

    public void AddPotion()
    {
        if (currentPotions < maxPotions)
        {
            currentPotions++;
            //Debug.Log("Potion +1 : " + currentPotions);
           
        }
        else
        {
            //Debug.Log("Cannot carry any more potions.");
           
        }
    }

    public void UsePotion()
    {
        if (currentPotions > 0)
        {
            PlayerHealth.instance.Healing(HealignAmount);
            currentPotions--;
           // Debug.Log("Potion used. Remaining potions: " + currentPotions);
        }
        else
        {
           // Debug.Log("No potions left.");
        }
    }

    public int GetCurrentPotionCount()
    {
        return currentPotions;
    }

    public void CoinCollected()
    {
        NumberOfCoins++;
        OnCoinsCollected.Invoke();
    }

}


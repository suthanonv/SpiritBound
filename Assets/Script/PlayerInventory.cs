using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxPotions = 3;
    private int currentPotions = 0;

    public static PlayerInventory Instance;

    private void Awake()
    {
        
        Instance = this;
    }

    public void AddPotion()
    {
        if (currentPotions < maxPotions)
        {
            currentPotions++;
            Debug.Log("Potion +1 : " + currentPotions);
           
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

}


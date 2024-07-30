using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PotionUIManager : MonoBehaviour
{
    public Image[] potionSlots; // Assign these in the Inspector
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.gray;
    private PlayerInventory playerInventory;

    public static PotionUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        UpdatePotionUI();
    }

    void Update()
    {
        UpdatePotionUI();
    }

    public void UpdatePotionUI()
    {
        for (int i = 0; i < potionSlots.Length; i++)
        {
            if (i < playerInventory.GetCurrentPotionCount())
            {
                potionSlots[i].gameObject.SetActive(true);
            }
            else
            {
                potionSlots[i].gameObject.SetActive(false);
            }
        }
    }
}




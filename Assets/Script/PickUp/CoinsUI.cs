using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    private TextMeshProUGUI coinsText;
    private PlayerInventory playerInventory;

    public static CoinsUI instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        UpdateCoinsText();
    }

    void Update()
    {
        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {
        coinsText.text = playerInventory.NumberOfCoins.ToString();
    }
}

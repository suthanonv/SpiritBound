using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsUI : MonoBehaviour
{

    private TextMeshProUGUI coinsText;

    public static CoinsUI instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinsText()
    {
        coinsText.text = PlayerInventory.Instance.NumberOfCoins.ToString();
    }
}

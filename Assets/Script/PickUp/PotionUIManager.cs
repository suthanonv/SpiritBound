using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PotionUIManager : MonoBehaviour
{
    [SerializeField] List<Sprite> PotionSpirte = new List<Sprite>(); 

    public Color activeColor = Color.green;
    public Color inactiveColor = Color.gray;
    private PlayerInventory playerInventory;

    public static PotionUIManager instance;

    public TextMeshProUGUI Cointext;

    [SerializeField] Image PotionImage;

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
        int CurrentPotion = playerInventory.GetCurrentPotionCount();

        PotionImage.sprite = PotionSpirte[CurrentPotion];
    }
}




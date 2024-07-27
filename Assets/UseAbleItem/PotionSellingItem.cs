using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSellingItem : ItemSelling
{
   
    void Start()
    {
        PriceText.text = ItemPrice.ToString();   
    }

    private void Update()
    {
        CanBuying();
    }

    public override void SuccessBuyyingItem()
    {
        PlayerInventory.Instance.AddPotion();
        Destroy(this.gameObject);
    }
}

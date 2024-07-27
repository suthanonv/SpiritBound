using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAblItemSelling : ItemSelling
{

    [SerializeField] UseAbleItem itemStat;
    private void Start()
    {
        PriceText.text = ItemPrice.ToString();
    }

    private void Update()
    {
        CanBuying();
    }

    public override void SuccessBuyyingItem()
    {
        ItemChoosingUIMangement.instance.ImportNewItem(itemStat);
        Destroy(this.gameObject);

    }

   

}


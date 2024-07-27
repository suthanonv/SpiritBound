using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemSelling : MonoBehaviour
{
    public int ItemPrice = 10;
    public TextMeshProUGUI PriceText;

    public GameObject E_Button;

    bool CanBuyed = false;
    public void OnBuyed()
    {
        if(PlayerInventory.Instance.NumberOfCoins >= ItemPrice)
        {
            PlayerInventory.Instance.NumberOfCoins -= ItemPrice;

            SuccessBuyyingItem();
        }
    }

   public void CanBuying()
    {
        if(PlayerInventory.Instance.NumberOfCoins >= ItemPrice)
        {
            PriceText.color = Color.yellow;
            CanBuyed = true;
        }
        else
        {
            PriceText.color = Color.red;
            CanBuyed = false;
        }
    }

    public virtual void SuccessBuyyingItem()
    {

    }

    public void OnSelteced(bool isSelceted)
    {
      if(CanBuyed == true)
        E_Button.SetActive(isSelceted);
      else E_Button.SetActive(false);
    }
}

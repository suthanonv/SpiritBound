using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using UnityEditorInternal.Profiling.Memory.Experimental;
using System;
public class ItemChoosingUIMangement : MonoBehaviour
{
    public static ItemChoosingUIMangement instance;

    [SerializeField] GameObject BlueCircleImage;

    [SerializeField] GameObject ChoosingItemPanel;

    [SerializeField] ItemShowingUI NewItemUI;
    [SerializeField] List<PlayerShowingUIStorage> ChoosingUI = new List<PlayerShowingUIStorage>();


 [NonSerialized]   public UseAbleItem NewItem;

    private void Awake()
    {
        instance = this;
    }


    public void ImportNewItem(UseAbleItem Item)
    {
        NewItem = Item;

        ChoosingItemPanel.SetActive(true);
        SpiritWorld.Instance.EnablePlayerMovementAndChagneForm(false);
        NewitemAnimationControlling.instance.SetNewItemBorderToOrigin();
        SetNewItemUI(Item);
        ShowingItemInPlayerStorage();
    }

    public void CloseChoosingItemPanel()
    {
        SpiritWorld.Instance.EnablePlayerMovementAndChagneForm(true);
        ChoosingItemPanel.SetActive(false);
        NewItem = null;
    }

    void SetNewItemUI(UseAbleItem Item)
    {
        foreach(Transform i in NewItemUI.ItemCountHolder)
        {
            Destroy(i.gameObject);
        }

        NewItemUI.SkillIcon.sprite = Item.SpriteIcon;
        NewItemUI.Name.text = Item.ItemName;
        NewItemUI.Description.text = Item.ItemDescription;

      if(Item.CDTime > 0)
        NewItemUI.CdText.text = ": " + Item.CDTime.ToString();
      else NewItemUI.CdText.text = "-";
        for ( int i = 0; i < Item.UsingLimitPerRoom; i++)
        {
            Instantiate(BlueCircleImage, NewItemUI.ItemCountHolder);
        }

    
    }


    public void ShowingItemInPlayerStorage()
    {
        foreach(PlayerShowingUIStorage i in ChoosingUI)
        {
            UseAbleItem itemInfo = UseAbleItemStorage.instance.GetItemInfo(i.StorageForm);


            foreach (Transform circle in i.Ui.ItemCountHolder)
            {
                Destroy(circle.gameObject);
            }

            if (itemInfo.ItemName == "none")
            {
                i.ItemIsNull.SetActive(true);
                foreach(GameObject d in i.ItemNotNull)
                {
                    d.SetActive(false);
                }
                continue;
            }
            else
            {
                i.ItemIsNull.SetActive(false);
                foreach (GameObject d in i.ItemNotNull)
                {
                    d.SetActive(true);
                }

                ItemShowingUI UiOfItem = i.Ui;
                UiOfItem.SkillIcon.sprite = itemInfo.SpriteIcon;
                UiOfItem.Name.text = itemInfo.ItemName;
                UiOfItem.Description.text = itemInfo.ItemDescription;
                
                if(itemInfo.CDTime > 0)
                UiOfItem.CdText.text = ": " + itemInfo.CDTime.ToString();
                else
                    UiOfItem.CdText.text = "-";

                for (int x = 0; x < itemInfo.UsingLimitPerRoom; x++)
                {
                    Instantiate(BlueCircleImage, UiOfItem.ItemCountHolder);
                }
            }
        }
    }

}

[System.Serializable]
public class PlayerShowingUIStorage
{
    public string FormName;
    public PlayerFormState StorageForm;
    [Header("Item Info Statea")]
    public GameObject ItemIsNull;
    public List<GameObject> ItemNotNull = new List<GameObject>();

    public ItemShowingUI Ui;
}

[System.Serializable]

public class ItemShowingUI
{
    [Header("Item Info")]
    public Image SkillIcon;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI CdText;
    public Transform ItemCountHolder;
}



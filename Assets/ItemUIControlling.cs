using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemUIControlling : MonoBehaviour
{
    [Header("In Game UI")]
    [SerializeField] Image IngameSkillIcon;


    [Header("Pause Menu UI")]
    [SerializeField] List<PauseMenuItemUI> pauseMenuItemUIs = new List<PauseMenuItemUI>();


    public static ItemUIControlling Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

    }



    public void SetInfoPauseMenuItemInfo()
    {
        for (int i = 0; i < pauseMenuItemUIs.Count; i++)
        {
            UseAbleItem ItemInfo = UseAbleItemStorage.instance.PlayerItemStorage[i].ItemInFormStorage;

            pauseMenuItemUIs[i].SetInfo(ItemInfo);
        }
    }
}


[System.Serializable]
public class PauseMenuItemUI
{
   public Image PauseMenuSkillIcon;
   public TextMeshProUGUI Item_DescriptionText;

    public void SetInfo(UseAbleItem item)
    {
        PauseMenuSkillIcon.sprite = item.SpriteIcon;
        Item_DescriptionText.text = item.ItemDescription;
    }
}

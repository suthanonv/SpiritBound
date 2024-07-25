using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemUIControlling : MonoBehaviour
{
    [Header("In Game UI")]
    [SerializeField] Image IngameSkillIcon;
    [SerializeField] GameObject CdPanel;
    [SerializeField] TextMeshProUGUI CountDownText;


    [SerializeField] Transform CountHolder;
    [SerializeField] GameObject Count;


    [Header("Pause Menu UI")]
    [SerializeField] List<PauseMenuItemUI> pauseMenuItemUIs = new List<PauseMenuItemUI>();


    public static ItemUIControlling Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UseAbleItem ItemInfo = UseAbleItemStorage.instance.GetItemInfo(SpiritWorld.Instance.playerFormState);
       if(ItemInfo.ItemName != "none")
        {
            IngameSkillIcon.sprite = ItemInfo.SpriteIcon;

            UseAbleItemSkill CurrentCdSKill = UseAbleItemStorage.instance.GetUseAbleItemSKill();


            if(CurrentCdSKill.RemainingUsedCount == 0) CountHolder.gameObject.SetActive(false);
            else CountHolder.gameObject.SetActive(true);    


          if(ItemInfo.UsingLimitPerRoom > 0)
            if(CountHolder.childCount != CurrentCdSKill.RemainingUsedCount)
            {


                int Different =  CurrentCdSKill.RemainingUsedCount  - CountHolder.childCount;

                if(Different > 0)
                {
                    for(int i = 0; i < Different; i++)
                    {
                        Instantiate(Count, CountHolder);
                    }
                }

                else if(Different < 0)
                {
                    Different *= -1;

                    for(int i = 0; i < Different; i++)
                    {
                       Destroy(CountHolder.GetChild(i).gameObject);
                    }
                }
            }


            if(CurrentCdSKill.CurrentCountDownCD > 0)
            {
                CdPanel.SetActive(true);
                CountDownText.text = CurrentCdSKill.CurrentCountDownCD.ToString();
            }
            else
            {
                CdPanel.SetActive(false);
            }
        }
       else
        {
            CountHolder.gameObject.SetActive(false);
            IngameSkillIcon.sprite = ItemInfo.SpriteIcon;
            CdPanel.SetActive(false);
        }
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

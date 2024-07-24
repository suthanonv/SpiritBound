using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
public class UseAbleItemStorage : MonoBehaviour
{
    public List<PlayerItemSkill> PlayerItemStorage = new List<PlayerItemSkill>();


    public static UseAbleItemStorage instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetItemInStorage();
    }

    public UseAbleItemSkill GetUseAbleItemSKill()
    {
        int Index = PlayerItemStorage.FindIndex(i => i.PlayerState == SpiritWorld.Instance.playerFormState);

        return PlayerItemStorage[Index].CurrentSkill;
    }


    public UseAbleItem GetItemInfo(PlayerFormState StateToGet)
    {
        int Index = PlayerItemStorage.FindIndex(i => i.PlayerState == StateToGet);

        return PlayerItemStorage[Index].ItemInFormStorage;
         
    }


    public void SetnewItem(UseAbleItem NewItem , PlayerFormState PlayerStateToStore)
    {
        int Index = PlayerItemStorage.FindIndex(i => i.PlayerState == PlayerStateToStore);


        PlayerItemStorage[Index].ItemInFormStorage = NewItem;

        SetItemInStorage();
    }


    public void SwapingItem()
    {
        UseAbleItem ItemHolder = PlayerItemStorage[0].ItemInFormStorage;

        PlayerItemStorage[0].ItemInFormStorage = PlayerItemStorage[1].ItemInFormStorage;

        PlayerItemStorage[1].ItemInFormStorage = ItemHolder;
    }


     void SetItemInStorage()
    {
        foreach (PlayerItemSkill item in PlayerItemStorage)
        {
            if (item.ItemInFormStorage.ItemSkill == null) continue;

            if (item.CurrentSkill != null) item.CurrentSkill.OnRemoveingItem();

            item.CurrentSkill = Instantiate(item.ItemInFormStorage.ItemSkill, transform.position, Quaternion.identity);
        }


        ItemUIControlling.Instance.SetInfoPauseMenuItemInfo();

    }
}

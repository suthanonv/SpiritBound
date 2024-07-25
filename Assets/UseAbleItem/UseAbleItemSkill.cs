using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class UseAbleItemSkill : MonoBehaviour
{
     public UseAbleItem ItemData;
    public int RemainingUsedCount;
    public bool ONCD;

    public PlayerFormState ItemInPlayerForm;

    public int CurrentCountDownCD = 0;

    public bool IsSkillOnCD()
    {
        return ONCD;
    }

    public virtual void OnHoldingKey()
    {

    }


     public virtual void OnRelesaingKey()
     {
        if (RemainingUsedCount == 0 && ONCD)
        {

            return;
        }
    
    
    }

     public  void StartItemCD()
     {
        ONCD = true;
        RemainingUsedCount--;
        StartCoroutine(CDItem(ItemData.CDTime));
     }

  
    IEnumerator CDItem(float timer)
    {
        CurrentCountDownCD = Mathf.RoundToInt(timer);
        while (CurrentCountDownCD > 0)
        {
            yield return new WaitForSeconds(1f);
            CurrentCountDownCD -= 1;
        }
        CurrentCountDownCD = 0;
        ONCD = false;
    }


    public virtual void ResetItemUseingCount()
    {
        RemainingUsedCount = ItemData.UsingLimitPerRoom;
        StopAllCoroutines();
        ONCD = false;

    }

    public void OnRemoveingItem()
    {
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

}

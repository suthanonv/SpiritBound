using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseAbleItemSkill : MonoBehaviour
{
     public UseAbleItem ItemData;
    protected int RemainingUsedCount;
    protected bool ONCD;

    public PlayerFormState ItemInPlayerForm;

    public bool IsSkillOnCD()
    {
        return ONCD;
    }

    public virtual void OnHoldingKey()
    {

    }


     public virtual void OnRelesaingKey()
     {
        if (RemainingUsedCount <= 0 && ONCD)
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

    IEnumerator CDItem(float TImer)
    {
        yield return new WaitForSeconds(TImer);
        ONCD = false;
    }


    public  virtual void ResetItemUseingCount()
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

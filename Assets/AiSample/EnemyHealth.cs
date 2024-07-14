using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] Room RoomThatEnemyInSide;


    [Header("Toughness")]
    [SerializeField] float MaxToughness;
    [SerializeField] float ToughnessResetPerioud = 5;
    [SerializeField] float ResetEnableToBreakTIme = 3;
  float CurrentToughness;
    bool canbreak = true;

    [SerializeField] Animator anim;

    Coroutine resetToughness;
   
    private void Start()
    {
        currenthealth = MaxHealth;
        CurrentToughness = MaxToughness;
    }

    public void Breaking(float BreakingDamage)
    {
        if (resetToughness != null) StopCoroutine(resetToughness);
        
        CurrentToughness -= BreakingDamage;

       
       if(CurrentToughness <= 0 && canbreak)
        {
            canbreak = false;
            anim.StopPlayback();
            anim.SetTrigger("Breaking");
            StartCoroutine(ResetBreakEnable());

        }
            StartCoroutine(StartResetToughness());
        
      

      
    }


    

    public override void Died()
    {
        RoomThatEnemyInSide.EnemyListInRoom.List.Remove(this.gameObject);
        Destroy(this.gameObject);
    }


    IEnumerator StartResetToughness()
    {
        yield return new WaitForSeconds(ToughnessResetPerioud);
        CurrentToughness = MaxToughness;
    }

    IEnumerator ResetBreakEnable()
    {
        yield return new WaitForSeconds(ResetEnableToBreakTIme);
        canbreak = true;
    }
}

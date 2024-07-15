using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : Health
{
    [SerializeField] Room RoomThatEnemyInSide;


    [Header("Toughness")]
    [SerializeField] float MaxToughness;
    [SerializeField] float ToughnessResetPerioud = 5;
    [SerializeField] float ResetEnableToBreakTIme = 3;
    [SerializeField] HealthBarAnimation HealthBar; 
  float CurrentToughness;
    bool canbreak = true;

    [SerializeField] Animator anim;

    Coroutine resetToughness;
   
    private void Start()
    {

        HealthBar.SetHealthBar(MaxHealth, currenthealth);
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


    public override void TakeDamage(float Damage)
    {
        float PreviosHealth = currenthealth;
        base.TakeDamage(Damage);
        HealthBar.HealthBarRunAnimation(currenthealth, PreviosHealth);

    }



    public override void Died()
    {
        RoomThatEnemyInSide.RemoveEnemyFromList(this.gameObject);
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

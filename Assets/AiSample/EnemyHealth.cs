using System;
using System.Collections;
using UnityEngine;
public class EnemyHealth : Health
{
[NonSerialized]    public Room RoomThatEnemyInSide;

    [SerializeField] GameObject ObjectParent;

    [Header("Toughness")]
    [SerializeField] float MaxToughness;
    [SerializeField] float ToughnessResetPerioud = 5;
    [SerializeField] float ResetEnableToBreakTIme = 3;
    [SerializeField] HealthBarAnimation HealthBar; 
  float CurrentToughness;
    bool canbreak = true;

    [SerializeField] Animator anim;

    Coroutine resetToughness;

    [SerializeField] DamageText ShowingDamageText;
   
    private void Start()
    {
     if(HealthBar != null) 
        HealthBar.SetHealthBar(MaxHealth, currenthealth);
        currenthealth = MaxHealth;
         CurrentToughness = MaxToughness;
    }

    public virtual void Breaking(float BreakingDamage)
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
        
        this.GetComponent<AudioSource>().Play();

        if(currenthealth - Damage > 0) ShowingDamageText.SetDamageText(Damage);

        base.TakeDamage(Damage);
        
        
        HealthBar.HealthBarRunAnimation(currenthealth, PreviosHealth);

    }


    [SerializeField] GameObject Parent;
    public override void Died()
    {
        RoomThatEnemyInSide.RemoveEnemyFromList(this.gameObject);
        Destroy(Parent);
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

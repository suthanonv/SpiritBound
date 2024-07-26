using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public static PlayerHealth instance;


    [SerializeField] HealthBarAnimation HealthBar;

    [SerializeField] GameObject HittingEffect;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        HealthBar.SetHealthBar(MaxHealth, currenthealth);
    }

    public override void TakeDamage(float Damage)
    {
        float previosHealth = currenthealth;
        currenthealth -= Damage;
        HealthBar.HealthBarRunAnimation(currenthealth , previosHealth);

        HittingEffect.SetActive(true);

        Invoke("OffHittingEffect", 0.125f);


    }

    public void Healing(float HealingAmount)
    {
        if (currenthealth + HealingAmount > MaxHealth) currenthealth = MaxHealth;
        else currenthealth += HealingAmount;

        HealthBar.HealthBarRunAnimation(currenthealth, currenthealth);

    }

    public override void Died()
    {
        
    }

    public void OffHittingEffect()
    {
        HittingEffect.SetActive(false);
    }
}

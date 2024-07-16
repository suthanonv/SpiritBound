using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public static PlayerHealth instance;


    [SerializeField] HealthBarAnimation HealthBar;


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
    }

    public override void Died()
    {
        
    }
}

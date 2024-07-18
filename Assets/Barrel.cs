using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : EnemyHealth
{

    [Header("Explosive Compoenet")]
    [SerializeField] ExplosiveHitBox ExplosiveHitBox;

    public override void TakeDamage(float Damage)
    {
        ExplosiveHitBox.gameObject.SetActive(true);
        ExplosiveHitBox.enabled = true;
    }

    public override void Breaking(float BreakingDamage)
    {
       
    }
    public override void Died()
    {
        
    }
}

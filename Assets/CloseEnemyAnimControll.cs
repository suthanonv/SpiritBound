using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyAnimControll :EnemiesAnimationController
{

    [SerializeField] GameObject AttackHitBox;
    public override void OnAttackAnimationStart()
    {
        base.OnAttackAnimationStart();
    }

    public override void OnBreaking()
    {
        AttackHitBox.SetActive(false);
        base.OnBreaking();
    }

    public override void OffBreaking()
    {
        base.OffBreaking();
    }

    public void Attacking()
    {

        AttackHitBox.SetActive(true);
    }

     public void OffAttackingHitBox()
    {
        base.OnAttackAnimationEnd();
        AttackHitBox.SetActive(false);
    }
}

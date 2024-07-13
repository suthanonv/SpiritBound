using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyAnimControll :EnemiesAnimationController
{

    [SerializeField] GameObject WarningHitBox;
    [SerializeField] GameObject AttackHitBox;
    public override void OnAttackAnimationStart()
    {
        WarningHitBox.SetActive(false);
        base.OnAttackAnimationStart();
    }


    public void Attacking()
    {
        WarningHitBox.SetActive(false);
        AttackHitBox.SetActive(true);
    }


     public void OffAttackingHitBox()
    {
        base.OnAttackAnimationEnd();
        AttackHitBox.SetActive(false);
    }
}

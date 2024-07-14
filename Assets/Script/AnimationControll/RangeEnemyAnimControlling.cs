using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAnimControlling : EnemiesAnimationController
{
    public  void Shooting()
    {
        RangeEnemy EnemyShootBehaviour = EnemyAttackScript as RangeEnemy;

        EnemyShootBehaviour.ShootingBullet();
    }


    public override void OffBreaking()
    {
        base.OffBreaking();
    }

    public override void OnBreaking()
    {
        base.OnBreaking();
    }
}

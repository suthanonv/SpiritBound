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
}

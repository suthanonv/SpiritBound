using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarAnimatControll : EnemiesAnimationController
{

    [SerializeField] Animator LaserAnim;

    public void Shooting()
    {
        MortarEnemyBehaviour EnemyShootBehaviour = EnemyAttackScript as MortarEnemyBehaviour;

        EnemyShootBehaviour.ShootingBullet();
    }

    public override void OnAttackAnimationStart()
    {
        this.GetComponent<Animator>().SetBool("OnAnimationFinish", false);
        EnemyMoveingBackWard RangeScript = AiMovement as EnemyMoveingBackWard;
        RangeScript.EnableNavMesh(false);
        base.OnAttackAnimationEnd();
    }

    public void ShootingLaser()
    {
        LaserAnim.gameObject.SetActive(true);

        LaserAnim.SetTrigger("Active");
    }

    public override void OnAttackAnimationEnd()
    {
        this.GetComponent<Animator>().SetBool("OnAnimationFinish", true);

        EnemyMoveingBackWard RangeScript = AiMovement as EnemyMoveingBackWard;
        RangeScript.EnableNavMesh(true);
        base.OnAttackAnimationEnd();
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

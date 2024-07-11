using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeEnemy : EnemieBehaviour
{
    bool NextAction = true;

    [SerializeField] Rigidbody Bullet;
    [SerializeField] Transform ShootingDirection;
    [SerializeField] float BulletForce = 5f;

    [SerializeField] Animator anim;

    private void Update()
    {
        if (CanDoingAction && IsAnimationDone()) Attack();
    
    
     
    
    }
    public override void Attack()
    {
        if(NextAction)
        {
            NextAction = false;
            StartCoroutine(DoingAction());
            StartCoroutine(ResetCDAction());
        }
    }



    bool IsAnimationDone()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
          {


            MovementScript.EnableWalk = false;
            return false;
           }

        else
        {
            MovementScript.EnableWalk = true;
            return true; }
    }


    IEnumerator DoingAction()
    {
        anim.SetTrigger("Attack");
         yield return new WaitForSeconds(AttackTimeAnim);
        ShootingBullet();
        
    }

    IEnumerator ResetCDAction()
    {
        yield return new WaitForSeconds(AttackCd);
        NextAction = true;
    }
    

    void ShootingBullet()
    {
        Rigidbody rb = Instantiate(Bullet, ShootingDirection);
        rb.transform.parent = null;

        rb.transform.position = ShootingDirection.transform.position;
        rb.velocity = ShootingDirection.forward * BulletForce;

       
    }




}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeEnemy : EnemieBehaviour
{

    [SerializeField] Rigidbody Bullet;
    [SerializeField] Transform ShootingDirection;
    [SerializeField] float BulletForce = 5f;

    [SerializeField] Animator anim;

    bool OffCD = true;


    private void Update()
    {
        if (OffCD && IsAnimationDone) Attack();
    
    
     
    
    }
    public override void Attack()
    {
        OffCD = false;
        DoingAction();
            StartCoroutine(ResetCDAction());
    }




    void DoingAction()
    {
        anim.SetTrigger("Attack");
                
    }

    IEnumerator ResetCDAction()
    {
        while (!IsAnimationDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(AttackCd);
        OffCD = true;
    }
    

   public void ShootingBullet()
    {
        Rigidbody rb = Instantiate(Bullet, ShootingDirection);
        rb.transform.parent = null;

        rb.transform.position = ShootingDirection.transform.position;
        rb.velocity = ShootingDirection.forward * BulletForce;

       
    }




}

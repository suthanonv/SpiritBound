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

    private void Update()
    {
        if (CanDoingAction) Attack();
    
    
     
    
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


    IEnumerator DoingAction()
    {
        
        MovementScript.EnableWalk = false;
        Debug.Log(MovementScript.EnableWalk);
         yield return new WaitForSeconds(AttackTimeAnim);
        MovementScript.EnableWalk = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarEnemyBehaviour : EnemieBehaviour
{

    [SerializeField] GameObject Nuke;

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
        Transform Player = this.GetComponent<Ai_Controllering>().Player;

        Instantiate(Nuke , new Vector3(Player.position.x , -16.86f , Player.position.z) , Quaternion.identity) ;
    }


}

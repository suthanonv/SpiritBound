using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyBehaviour : EnemieBehaviour
{

    [SerializeField] Animator anim;

    bool NextAction = true;

    private void Update()
    {
   
        if (MovementScript.isInRange(ActionRange)) Attack();




    }
    public override void Attack()
    {
        if (NextAction && IsAnimationDone)
        {
            NextAction = false;
            DoingAction();
            StartCoroutine(ResetCDAction());
        }
    }





    void DoingAction()
    {
        anim.SetTrigger("Attack");
    }

    IEnumerator ResetCDAction()
    {
     while(!IsAnimationDone)
        {
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(AttackCd);
        NextAction = true;
        MovementScript.EnableWalk = true;
    }



}

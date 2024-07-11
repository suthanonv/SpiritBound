using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyBehaviour : EnemieBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] GameObject WarningBox;
    [SerializeField] GameObject ColliderBox;
    

    bool NextAction = true;

    private void Update()
    {
        bool isAnimationDone = IsAnimationDone();
        if (MovementScript.isInRange(ActionRange) && isAnimationDone) Attack();




    }
    public override void Attack()
    {
        if (NextAction)
        {
            NextAction = false;
            StartCoroutine(DoingAction());
            StartCoroutine(ResetCDAction());
        }
    }



    bool IsAnimationDone()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
           
            MovementScript.EnableWalk = false;
            return false;
        }
        else
        {
            ColliderBox.SetActive(false);
            MovementScript.EnableWalk = true;
            return true;
        }
    }


    IEnumerator DoingAction()
    {
        anim.SetTrigger("Attack");
        WarningBox.SetActive(true);
        yield return new WaitForSeconds(AttackTimeAnim);
        WarningBox.SetActive(false);
        ColliderBox.SetActive(true);
        ColliderBox.SetActive(false);

        //enableCollider

    }

    IEnumerator ResetCDAction()
    {
        yield return new WaitForSeconds(AttackCd);
        NextAction = true;
        MovementScript.EnableWalk = true;
    }



}

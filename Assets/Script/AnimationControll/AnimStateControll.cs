using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateControll : MonoBehaviour
{
    public PlayerAttack PlayerAttackScript;
    public ChracterMovement moveScript;

    [SerializeField] GameObject HitBox1;
    [SerializeField] GameObject HitBox2;
    [SerializeField] GameObject HitBox3;

    [SerializeField] SpiritForm ChangeFormScript;

    public void StartAnimation()
    {
        ChangeFormScript.enabled = false;
        PlayerAttackScript.isAnimationDone = false;
        moveScript.enabled = false;
        
    }

    public void OpenCollider(int AttackCount)
    {
      if(AttackCount == 1)
        HitBox1.SetActive(true);
      else if(AttackCount == 2)
        HitBox2.SetActive(true);
        else if (AttackCount == 3)
            HitBox3.SetActive(true);
    }

    public void AnimationEnd()
    {
        ChangeFormScript.enabled = true;

        PlayerAttackScript.isAnimationDone = true;
        moveScript.enabled = true;
        HitBox1.SetActive(false);
        HitBox2.SetActive(false);
        HitBox3.SetActive(false);


    }
}

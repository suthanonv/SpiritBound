using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float AttackPeriod = 0.25f;
    [SerializeField] GameObject AttackBox1;
    [SerializeField] GameObject AttackBox2;
    [SerializeField] GameObject AttackBox3;

    [SerializeField] Animator anim;

    [SerializeField] float AtkCD;
    float currentCD = 0;
    public float nextFiretime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 2;




    private void Update()
    {
       
        if (currentCD <= 0 && CanDoingNextAttack()) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && currentCD <= 0)
            {
                currentCD = AtkCD;
                Attack();
            }
        }
        if(currentCD > 0) currentCD -= Time.deltaTime;

        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
    }


    void CheckAttackState()
    {

    }


    void Attack()
    {
        StartCoroutine(OnAttack());
    }


    bool CanDoingNextAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            this.GetComponent<PlayerMover>().enabled = false;
            return false;
        }
        else
        {
            this.GetComponent<PlayerMover>().enabled = true;
            return true;
        }

    }


    IEnumerator OnAttack()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
       


        if (noOfClicks == 1)
        {
            anim.SetInteger("AtkCount", noOfClicks);
            anim.SetTrigger("Attack");
            AttackBox1.SetActive(true);
            yield return null;
            AttackBox1.SetActive(false);
        }

        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        if (noOfClicks == 2)
        {
            anim.SetInteger("AtkCount", noOfClicks);
            anim.SetTrigger("Attack");
            AttackBox1.SetActive(false);
            AttackBox2.SetActive(true);
            yield return null;
            AttackBox1.SetActive(false);
            AttackBox2.SetActive(false);
        }

        if (noOfClicks == 3)
        {
            anim.SetInteger("AtkCount", noOfClicks);
            anim.SetTrigger("Attack");
            AttackBox1.SetActive(false);
            AttackBox2.SetActive(false);
            AttackBox3.SetActive(true);
            yield return null;
            AttackBox1.SetActive(false);
            AttackBox2.SetActive(false);
            AttackBox3.SetActive(false);
            noOfClicks = 0;
        }  
    }



}

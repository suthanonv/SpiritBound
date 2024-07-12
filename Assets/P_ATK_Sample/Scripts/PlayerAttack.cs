using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float AttackPeriod = 0.25f;


    [SerializeField] Animator anim;

    [SerializeField] float AtkCD;
    float currentCD = 0;
    public float nextFiretime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;


     public   bool offAtttack = true;


    public bool isAnimationDone = true;
  
    


    private void Update()
    {
    
      
        if (currentCD <= 0 && isAnimationDone)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && currentCD <= 0)
            {
                currentCD = AtkCD;
                Attack();
            }
        }
        if (currentCD > 0) currentCD -= Time.deltaTime;

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
    }





    void Attack()
    {
        StartCoroutine(OnAttack());
    }





        IEnumerator OnAttack()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
       


        if (noOfClicks == 1)
        {
            anim.SetInteger("AtkCount", noOfClicks);
            anim.SetTrigger("Attack");

            yield return new WaitForSeconds(0.1f);

           
        }

        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        if (noOfClicks == 2)
        {
            anim.SetInteger("AtkCount", noOfClicks);
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.2f);
            yield return null;
        }

        if (noOfClicks == 3)
        {
            anim.SetInteger("AtkCount", noOfClicks);
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.15f);

            yield return null;

            noOfClicks = 0;
        }  
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float AttackPeriod = 0.25f;
    [SerializeField] GameObject AttackBox1;
    [SerializeField] GameObject AttackBox2;
    [SerializeField] GameObject AttackBox3;

    [SerializeField] float AtkCD;
    float currentCD = 0;
    public float nextFiretime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

    private void Update()
    {
        if (Time.time > nextFiretime) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && currentCD <= 0)
            {
                currentCD = AtkCD;
                Attack();
            }
        }
        if(currentCD > 0) currentCD-= Time.deltaTime;

        if(Time.time - lastClickedTime > maxComboDelay)
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
            this.GetComponent<PlayerMover>().enabled = false;
            AttackBox1.SetActive(true);
            yield return new WaitForSeconds(AttackPeriod);
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox1.SetActive(false);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks == 2)
        {
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox1.SetActive(false);
            this.GetComponent<PlayerMover>().enabled = false;
            AttackBox2.SetActive(true);
            yield return new WaitForSeconds(AttackPeriod);
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox1.SetActive(false);
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox2.SetActive(false);
        }

        if (noOfClicks == 3)
        {
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox1.SetActive(false);
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox2.SetActive(false);
            this.GetComponent<PlayerMover>().enabled = false;
            AttackBox3.SetActive(true);
            yield return new WaitForSeconds(AttackPeriod);
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox1.SetActive(false);
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox2.SetActive(false);
            this.GetComponent<PlayerMover>().enabled = true;
            AttackBox3.SetActive(false);
            noOfClicks = 0;
        }

        
    }
}

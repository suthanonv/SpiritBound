using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosiveHitBox : MonoBehaviour
{

    [SerializeField] GameObject Barel;

    List<Health> PlayerHealths = new List<Health>();

    List<EnemyHealth> EnemyHealth = new List<EnemyHealth>();

    [SerializeField] float ActivateTime  = 1.5f;
    [SerializeField] DamageAreaEffect CircleArea;


    [Header("Damage")]

    [SerializeField] float EnemyBreakDamage = 100;
    [SerializeField] float EnemyDamage = 50;

    [SerializeField] float PlayerDamage = 25;



    [SerializeField] GameObject ExplosiveEffect;
    [SerializeField] Transform ExplosivePreSet;

     
    private void OnEnable()
    {
        CircleArea.enabled = true;
        Invoke("Explosive", ActivateTime);
    }



    
    void Explosive()
    {
        foreach (Health health in PlayerHealths)
        {
            if(health != null)
            {           
                    health.TakeDamage(PlayerDamage);
            }
        }

        foreach(EnemyHealth enemy in EnemyHealth)

        {
            if(enemy != null)
            {
                enemy.TakeDamage(EnemyDamage);
                enemy.Breaking(EnemyBreakDamage);

            }
        }


        SoundEffectManageMent.Instance.GetSoundScripting("Explosion").PlayeringSound();
        Instantiate(ExplosiveEffect, ExplosivePreSet.transform.position, Quaternion.identity);
        Destroy(Barel);
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Health health = PlayerHealth.instance;

          Health Check = PlayerHealths.FirstOrDefault(i => i == health);

            if (Check == null)
            {
                PlayerHealths.Add(health);

            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                EnemyHealth check = EnemyHealth.FirstOrDefault(i => i == enemyHealth);

                if (check == null)
                {

                    EnemyHealth.Add(enemyHealth);
                    Debug.Log("Adding Enemy");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health health = PlayerHealth.instance;

            PlayerHealths.Remove(health);

        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealt = other.GetComponent<EnemyHealth>();

            EnemyHealth.Remove(enemyHealt);
            Debug.Log("Removeing");
        }
    }
}

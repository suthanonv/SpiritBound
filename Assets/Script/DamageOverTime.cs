using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] float DamageToEnemy = 5;
    [SerializeField] float BreakDamage = 1;
    [SerializeField] float HitCD = 0.25f;






    List<TrapDamageToEntityCD> trapDamageToEntityCDs = new List<TrapDamageToEntityCD>();




    private void OnTriggerStay(Collider other)
    {
       
            if (other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {

                TrapDamageToEntityCD checkIsInList = trapDamageToEntityCDs.FirstOrDefault(i => i.ObjectToDamage == other.gameObject);

                if (checkIsInList == null)
                {
                    TrapDamageToEntityCD newEnetity = new TrapDamageToEntityCD(other.gameObject);

                    trapDamageToEntityCDs.Add(newEnetity);
                    enemy.TakeDamage(DamageToEnemy);
                    enemy.Breaking(BreakDamage);
                    StartCoroutine(newEnetity.ResetCD(trapDamageToEntityCDs , HitCD));
                }
            }

          
        
    }
}

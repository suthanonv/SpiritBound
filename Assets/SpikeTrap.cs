using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpikeTrap : MonoBehaviour
{

    [Header("Damage")]
    [SerializeField] float DamageToPlayer = 5;
    [SerializeField] float DamageToEnemy = 10;

    [SerializeField] Animator anim;

    bool CanDamageToEntity = true;


    bool isActive = false;
    bool CanRunAnimation = true;
    bool CanDamage;



    List<TrapDamageToEntityCD> trapDamageToEntityCDs = new List<TrapDamageToEntityCD>();
 
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && CanRunAnimation)
        {
            CanRunAnimation = false;
            anim.SetTrigger("Active");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {

                TrapDamageToEntityCD checkIsInList = trapDamageToEntityCDs.FirstOrDefault(i => i.ObjectToDamage == other.gameObject);

                if (checkIsInList == null)
                {
                    TrapDamageToEntityCD newEnetity = new TrapDamageToEntityCD(other.gameObject);

                    trapDamageToEntityCDs.Add(newEnetity);
                    enemy.TakeDamage(DamageToEnemy);
                    StartCoroutine(newEnetity.ResetCD(trapDamageToEntityCDs));
                }
            }

            if (other.CompareTag("Player"))
            {
                TrapDamageToEntityCD checkIsInList = trapDamageToEntityCDs.FirstOrDefault(i => i.ObjectToDamage == other.gameObject);

                if (checkIsInList == null)
                {
                    TrapDamageToEntityCD newEnetity = new TrapDamageToEntityCD(other.gameObject);

                    trapDamageToEntityCDs.Add(newEnetity);
                    PlayerHealth.instance.TakeDamage(DamageToPlayer);
                    StartCoroutine(newEnetity.ResetCD(trapDamageToEntityCDs));
                }
            }
        }
    }

    public void OnSpikeActive()
    {
        isActive = true;
    }

    public void OffSPikeActive()
    {
        isActive = false;
        CanRunAnimation = true;
    }

}

[System.Serializable]
public class TrapDamageToEntityCD
{
    public GameObject ObjectToDamage;
    public bool CanDamage = true;


    public TrapDamageToEntityCD(GameObject SetObject)
    {
        ObjectToDamage = SetObject;
    }


   public IEnumerator ResetCD(List<TrapDamageToEntityCD> RemoveingList)
    {

        yield return new WaitForSeconds(0.1f);
        CanDamage = true;

        RemoveingList.Remove(this);
    }
}
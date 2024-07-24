using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeDamage : MonoBehaviour
{
    [SerializeField] float Damage = 20;
    [SerializeField] GameObject ExplotionEffect;
    [SerializeField] float EffectPeirod = 0.125f;
    [SerializeField] GameObject SecondColiider;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
                PlayerHealth.instance.TakeDamage(Damage);
            Destroy(this.gameObject);
   
        }

        if(other.gameObject.CompareTag("Floor"))
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;


     
            GameObject ExplotionEffectPrefab = Instantiate(ExplotionEffect, this.transform.position, Quaternion.identity);
            
            Destroy(this.gameObject, 0.1f);
            Destroy(ExplotionEffectPrefab, EffectPeirod);

            SecondColiider.SetActive(true);
        }
    }
}

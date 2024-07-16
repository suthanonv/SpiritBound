using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderDamage : MonoBehaviour
{
    [SerializeField] float Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) PlayerHealth.instance.TakeDamage(Damage);
    }
}

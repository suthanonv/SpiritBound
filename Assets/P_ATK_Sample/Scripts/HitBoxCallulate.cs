using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCallulate : MonoBehaviour
{
    [SerializeField] float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            health.TakeDamage(Damage);
        }
    }
}

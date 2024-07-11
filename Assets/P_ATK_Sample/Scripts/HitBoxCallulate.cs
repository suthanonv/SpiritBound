using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCallulate : MonoBehaviour
{
    [SerializeField] float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(Damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCallulate : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] float BreakEfficiency;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            health.Breaking(BreakEfficiency);
            health.TakeDamage(Damage);
        }



        if (other.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(other.gameObject);
        }
    }
}

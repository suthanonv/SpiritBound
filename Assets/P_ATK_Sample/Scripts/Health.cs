using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected float currenthealth = 100;
   [SerializeField] protected float MaxHealth = 0;






    public virtual void TakeDamage(float Damage)
    {

        currenthealth -= Damage;
        if(currenthealth <= 0)
        {
            Died();
        }
    }


    public virtual void Died()
    {

    }

}

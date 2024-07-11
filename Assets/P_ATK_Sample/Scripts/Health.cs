using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Health : MonoBehaviour
{
     float currenthealth = 100;

     public float CurrentHealth
     {
        get { return currenthealth; }
        set { currenthealth = value;
            if (currenthealth <= 0) this.gameObject.SetActive(false); 
        }
    }


    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
    }

}

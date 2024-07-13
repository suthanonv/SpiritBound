using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBehaviour : MonoBehaviour
{
    [NonSerialized]public bool CanDoingAction;
    [SerializeField] public float ActionRange;
    [SerializeField] public float AttackCd;
    [SerializeField] protected float AttackTimeAnim;
    public Ai_Controllering MovementScript;
   public bool IsAnimationDone = true;


    public virtual void Attack()
    {

    }
 
}

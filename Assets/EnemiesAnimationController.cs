using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesAnimationController : MonoBehaviour
{

    [SerializeField] protected Ai_Controllering AiMovement;
    [SerializeField] protected EnemieBehaviour EnemyAttackScript;
    [SerializeField] protected NavMeshAgent NevMesh;

    public virtual void OnAttackAnimationStart()
    {
        AiMovement.enabled = false;
           EnemyAttackScript.IsAnimationDone = false;
        NevMesh.enabled = false;
    }

   
  
    public virtual void OnAttackAnimationEnd()
    {


        NevMesh.enabled = true;
        AiMovement.enabled = true;
        EnemyAttackScript.IsAnimationDone = true;
       



    }
}

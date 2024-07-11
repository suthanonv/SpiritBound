using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Controllering : MonoBehaviour
{
  protected  NavMeshAgent Agent;
    [SerializeField] protected EnemieBehaviour EnemeyBehaviour;
    protected Transform Player;
   [SerializeField] protected float AttackRange;
    [SerializeField] protected float ChasingRange;
   

    bool enablewalk;

  [NonSerialized] public Vector3 DifBetweenPlayer = Vector3.zero;

    public bool EnableWalk
    {
        get { return enablewalk; }
        set
        {
            enablewalk = value;
            if (enablewalk == false)
            {
                Agent.isStopped = true;
                Agent.destination = this.transform.position;
            }
           
        }
    }



    protected virtual void MovePosition(Vector3 destinition)
    {
        Agent.destination = destinition;
        Agent.isStopped = false;
    }

    public bool isInRange(float ActionRnage)
    {
         DifBetweenPlayer = this.transform.position - Player.transform.position;

        if (DifBetweenPlayer.magnitude <= ActionRnage)
        {
            return true;
        }
        return false;
    }

}

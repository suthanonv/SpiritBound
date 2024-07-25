using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Controllering : MonoBehaviour
{
  protected  NavMeshAgent Agent;
    [SerializeField] protected EnemieBehaviour EnemeyBehaviour;
    public Transform Player;
   [SerializeField] protected float AttackRange;
    [SerializeField] protected float ChasingRange;
    [SerializeField] public PlayerFormState EnemyForm = PlayerFormState.physic;
   

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
        if(Player == null) Player = SpiritWorld.Instance.GetPlayer(EnemyForm).transform;

        DifBetweenPlayer = this.transform.position - Player.transform.position;

        if (DifBetweenPlayer.magnitude <= ActionRnage)
        {
            return true;
        }
        return false;
    }


    [NonSerialized] public GameObject ProvokeDestination;
 public bool isProvoke = false;
    public void IsProvoking(bool Provoke , GameObject ObjectToProve)
    {
       
        isProvoke = Provoke;
        if (isProvoke)
        {

            ObjectToProve.GetComponent<Fumo>().ProvokedEnemyList.Add(this.gameObject);
            ProvokeDestination = ObjectToProve;

        }
    }

    protected Transform GetDestination()
    {
        if(isProvoke)
        {
         
           return ProvokeDestination.transform;

        }
        else
        {
            return  SpiritWorld.Instance.GetPlayer(EnemyForm).transform;
        }

    }

}

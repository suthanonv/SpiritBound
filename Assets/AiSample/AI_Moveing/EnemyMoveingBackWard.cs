using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveingBackWard : Ai_Controllering
{

    void Start()
    {
        EnableWalk = true;
        Agent = this.GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame


    [SerializeField] Animator anim;
    void Update()
    {
        Player = SpiritWorld.Instance.player.transform;
        Vector3 DifBetweenPlayer = this.transform.position - Player.transform.position;

        EnemeyBehaviour.CanDoingAction = true;
        


        if (EnableWalk)
        {
            transform.LookAt(Player.transform.position);
            if (DifBetweenPlayer.magnitude < AttackRange)
            {
                
                MovePosition(this.transform.position);
                
            }
        }

      
    }


   
  

    protected override void MovePosition(Vector3 EnemiePosition)
    {
        
        Vector3 DifBetweenPlayer = EnemiePosition - Player.transform.position;
        Vector3 destinition = EnemiePosition - (DifBetweenPlayer.normalized * (DifBetweenPlayer.magnitude - AttackRange));
        base.MovePosition(destinition);
        
        if(destinition  == this.transform.position) anim.SetFloat("speed", 0);
        else anim.SetFloat("speed", 1);

    }

}

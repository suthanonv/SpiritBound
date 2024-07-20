using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class EnemyMoveingBackWard : Ai_Controllering
{
    enum AiStateMent
    { Stop, Move }



    [Header("AI State")]
    [SerializeField] float MoveingPeriod = 3.5f;
    [SerializeField] float StopPeriod = 5f;
    bool ChangedCD = false;
    AiStateMent CurrentState = AiStateMent.Move;
    void Start()
    {
        EnableWalk = true;
        Agent = this.GetComponent<NavMeshAgent>();
        Player = SpiritWorld.Instance.GetPlayer(EnemyForm).transform;

    }

    // Update is called once per frame


    [SerializeField] Animator anim;
    void Update()
    {
        Player = SpiritWorld.Instance.GetPlayer(EnemyForm).transform;

        Vector3 DifBetweenPlayer = this.transform.position - Player.transform.position;

        EnemeyBehaviour.CanDoingAction = true;



        if (EnableWalk)
        {
            AIChangeState();



            transform.LookAt(Player.transform.position);

            if (CurrentState == AiStateMent.Move)
            {
                anim.SetFloat("speed", 1);
                MovePosition(this.transform.position);
              
            }
            else
            {
                anim.SetFloat("speed", 0);

                Agent.destination = this.transform.position;
            }

    }


}

    void AIChangeState()
    {
       if(!ChangedCD)
        {
            ChangedCD = true;
            if (CurrentState == AiStateMent.Move)
            {
                CurrentState = AiStateMent.Stop;
                StartCoroutine(StateChangeCD(StopPeriod));

            }
            else
            {
                CurrentState = AiStateMent.Move;
                StartCoroutine(StateChangeCD(MoveingPeriod));

            }

        }
    }

    IEnumerator StateChangeCD(float Time)
    { 
    yield return new WaitForSeconds(Time);
        ChangedCD = false;
    }


    protected override void MovePosition(Vector3 EnemiePosition)
    {

        Vector3 DifBetweenPlayer = EnemiePosition - Player.transform.position;
        Vector3 destinition = EnemiePosition - (DifBetweenPlayer.normalized * (DifBetweenPlayer.magnitude - AttackRange));
        bool CanMove = Agent.pathStatus == NavMeshPathStatus.PathComplete;

     
        base.MovePosition(destinition);
    }


     public void EnableNavMesh(bool IsEnable)
    {
        if(IsEnable == false )
        {
            Agent.enabled = false;
            anim.SetFloat("speed", 0);
        }
        else
        {
            Agent.enabled = true;

            if (CurrentState == AiStateMent.Move)
                anim.SetFloat("speed", 1);
            else anim.SetFloat("speed", 0);
        }
    }
}

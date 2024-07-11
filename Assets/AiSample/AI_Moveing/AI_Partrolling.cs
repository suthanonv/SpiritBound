using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI_Partrolling : MonoBehaviour
{
    [SerializeField] List<Transform> PatrollingPoint = new List<Transform>();
    [SerializeField] Transform Player;

    [SerializeField] NavMeshAgent Agent;
    [SerializeField] bool OnRage = false;

    int PatrollIndex = 0;

    // Update is called once per frame

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!OnRage)
        {
            Partrolling();
         }
         else
        {
            AttackingPlayer();
        }
    }


    void AttackingPlayer()
    {
        Agent.destination = Player.transform.position;
    }


    void Partrolling()
    {
        Transform Desinition = PatrollingPoint[PatrollIndex];


        Vector3 Lenght = this.transform.position - Desinition.transform.position;




        if (Lenght.magnitude < 1.5f)
        {
            PatrollIndex++;
            if(PatrollIndex >= PatrollingPoint.Count)
            {
                PatrollIndex = 0;
            }
        }

        Agent.destination = Desinition.transform.position;
    }
}

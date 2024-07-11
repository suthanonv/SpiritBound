using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloseEnemyMovement : Ai_Controllering
{
    void Start()
    {
        EnableWalk = true;
        Agent = this.GetComponent<NavMeshAgent>();
        Player = SpiritWorld.Instance.player.transform; 
    }

    // Update is called once per frame


   

    [SerializeField] Animator anim;
    void Update()
    {
        Player = SpiritWorld.Instance.player.transform;
        Vector3 DifBetweenPlayer = this.transform.position - Player.transform.position;




        if (EnableWalk)
        {
            Vector3 targetPosition = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(targetPosition);
        
            if (DifBetweenPlayer.magnitude <= ChasingRange && DifBetweenPlayer.magnitude >= AttackRange) 
            {
                MovePosition(Player.transform.position);
            }
            else
            {
                MovePosition(this.transform.position);
            }
        }


    }





    protected override void MovePosition(Vector3 destinationToMove)
    {

        if (destinationToMove == this.transform.position) anim.SetFloat("speed", 0);
        else anim.SetFloat("speed", 1);

        base.MovePosition(destinationToMove);

        

    }

}

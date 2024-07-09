using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PawnController
{



    private void Start()
    {
       cc = this.GetComponent<CharacterController>();
    }


    private void Update()
    {
        MoveDirection.x = Input.GetAxisRaw("Horizontal");
        MoveDirection.z = Input.GetAxisRaw("Vertical");
        MoveDirection.Normalize();

        Moveing(MoveDirection * MoveSpeed * Time.deltaTime);

       
    }


    private void FixedUpdate()
    {
      
    }
    public override void Moveing(Vector3 MoveDirection)
    {
      
        cc.Move(MoveDirection);
    }


    public void Teleport(Transform Destination)
    {
        cc.enabled = false;
        this.transform.position = Destination.position;
        cc.enabled = true;
    }
}

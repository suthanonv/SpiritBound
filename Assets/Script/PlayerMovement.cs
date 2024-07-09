using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
 [SerializeField] Rigidbody rb;
    Vector3 movement;

    [SerializeField] float Speed;
 

    private void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");

        movement = new Vector3(X, 0, Z);
    }



    private void FixedUpdate()
    {
        if (rb.velocity.y >= 0)
        
        rb.velocity = movement.normalized * Speed;
    }
}

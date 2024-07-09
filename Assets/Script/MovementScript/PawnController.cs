using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PawnController : MonoBehaviour
{
  [SerializeField]  protected CharacterController cc;
    protected Vector3 MoveDirection;


   public float MoveSpeed = 6f;
   public float Gravitys = -9.81f;


    public virtual void Moveing(Vector3 MoveDirection)
    {
     
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(FollowMouse))]
public class TopDownCharacterMover : MonoBehaviour
{
    public float rotationSpeed = 10f;
    float currentSpeed = 0;
    public float moveSpeed = 5f;

    bool isDashing;


    [Header("Dash Detail")]
    [SerializeField] float DashSpeedMultiple = 2;
   
    [SerializeField] float DashDuration = 0.25f;
    [SerializeField] KeyCode DashKey = KeyCode.LeftShift;
    Vector3 dashDirect = Vector3.zero;
    float lastDashTime;
    float dashTime;

    private void Start()
    {
        currentSpeed = moveSpeed;
    }


    private void Update()
    {
        // Rotate the character towards the mouse position
        RotateTowardsMouse();

        
        if(Input.GetKeyDown(DashKey))
        {
            StartDash();
        }

        Dash();

       if(Canwalk())  
        HandleMovement();



    }

    private void RotateTowardsMouse()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y - transform.position.y; // Adjust the depth to character's height

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.y = transform.position.y; // Keep the same height as the character

        // Determine the direction to rotate towards
        Vector3 direction = mouseWorldPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleMovement()
    {
        // Get the current forward direction of the character
        Vector3 forwardDirection = transform.forward;

        // Normalize the movement direction to prevent faster diagonal movement
        forwardDirection.Normalize();

        dashDirect = forwardDirection;
        // Handle movement based on WASD keys
        if (Input.GetKey(KeyCode.W))
        {
            MoveChar(forwardDirection);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveChar(-forwardDirection);

        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveChar(-transform.right);


        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveChar(transform.right);
            

        }
    }
    public float raycastDistance = 10f;
    void MoveChar(Vector3 direct)
   {
        Ray ray = new Ray(transform.position, direct);
        RaycastHit hit;

      
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {  
        }
        else transform.Translate(direct * currentSpeed * Time.deltaTime, Space.World);
    }


    private void StartDash()
    {
        isDashing = true;
        dashTime = Time.time + DashDuration;
        lastDashTime = Time.time;
    }

    private void Dash()
    {
        if (Time.time >= dashTime)
        {
            currentSpeed = moveSpeed;
            isDashing = false;
            return;
        }

        currentSpeed = moveSpeed * DashSpeedMultiple;
        //var dashVector = transform.forward * DashSpeed * Time.deltaTime;
        //transform.Translate(dashVector);
    }

    bool canWalk = true;

    List<GameObject> GameObjectThatCollidedWihtPlayer = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Floor"))
        {
            GameObjectThatCollidedWihtPlayer.Add(collision.gameObject);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Floor"))
       GameObjectThatCollidedWihtPlayer.Remove(collision.gameObject);
    }

    bool Canwalk()
    {
        if (GameObjectThatCollidedWihtPlayer.Count == 0) return true; return false;
    }

}
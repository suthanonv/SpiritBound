using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowMouse))]
public class SpiritController : MonoBehaviour 
{
    [Header("Spirit Controller")]
    public float rotationSpeed = 10f;
    float currentSpeed = 0;
    public float moveSpeed = 5f;

    bool isDashing;



    [Header("Dash Detail")]
    [SerializeField] float DashSpeedMultiple = 2;

    [SerializeField] float DashDuration = 0.25f;
    [SerializeField] KeyCode DashKey = KeyCode.LeftShift;
    Vector3 dashDirect = Vector3.zero;
    float dashTime;
    float lastDashTime;
   
    private void Start()
    {
        currentSpeed = moveSpeed;
    }


    private void Update()
    {
        // Rotate the character towards the mouse position
        RotateTowardsMouse();


        if (Input.GetKeyDown(DashKey))
        {
            StartDash();
        }

        Dash();

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
            transform.Translate(forwardDirection * currentSpeed * Time.deltaTime, Space.World);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-forwardDirection * currentSpeed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * currentSpeed * Time.deltaTime, Space.World);


        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * currentSpeed * Time.deltaTime, Space.World);


        }
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
       
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownCharacterMover : PlayerMover
{
    public float rotationSpeed = 10f;
    float currentSpeed = 0;
    public float moveSpeed = 5f;
    private PlayerInventory playerinventory;
    public Animator anim;

    [Header("Dash Detail")]
    [SerializeField] float DashSpeedMultiple = 2;
    [SerializeField] float DashDuration = 0.25f;
    [SerializeField] KeyCode DashKey = KeyCode.LeftShift;
    [SerializeField] float DashCoolDown = 1.5f;
    Vector3 dashDirect = Vector3.zero;
    float lastDashTime;
    float dashTime;


    [Header("Spirit Controller")]
    public bool IsSpirit = false;
    public GameObject player;
    public float maxDistance = 10f;

    [Header("Use Potion Key")]
    [SerializeField] KeyCode Health = KeyCode.E;



    private void Start()
    {
        currentSpeed = moveSpeed;
        playerinventory = GetComponent<PlayerInventory>();
    }
    


    private void Update()
    {
        // Rotate the character towards the mouse position
        RotateTowardsMouse();


        if (Input.GetKeyDown(DashKey) && Time.time >= lastDashTime + DashCoolDown)
        {
            StartDash();
        }

       


        Dash();

     
        HandleMovement();

        if (IsSpirit)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position); //check distance between the spirit and the player
            if (distance > maxDistance)
            {
                Vector3 direction = (transform.position - player.transform.position).normalized;
                transform.position = player.transform.position + direction * maxDistance;
            }

        }

        if(Input.GetKeyDown(Health))
        {
            playerinventory.UsePotion();
            FindObjectOfType<PotionUIManager>().UpdatePotionUI();
        }
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
        Vector3 movementDirection = Vector3.zero;

        Vector3 forwardDirection = transform.forward;

        // Normalize the movement direction to prevent faster diagonal movement
        forwardDirection.Normalize();

        dashDirect = forwardDirection;
        // Handle movement based on WASD keys
        if (Input.GetKey(KeyCode.W))
        {
            
            MoveChar(forwardDirection);
            movementDirection += forwardDirection;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveChar(-forwardDirection);
            movementDirection -= forwardDirection;

        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveChar(-transform.right);
            movementDirection -= transform.right;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveChar(transform.right);
            movementDirection += transform.right;
        }

       
        anim.SetFloat("Speed", movementDirection.sqrMagnitude);
    }
    public float raycastDistance = 10f;
    [SerializeField] LayerMask LayerToDetection = 0;
    [SerializeField] float RayCaseRadius;
    void MoveChar(Vector3 direct)
   {
        Ray ray = new Ray(transform.position, direct);
        RaycastHit hit;

      
        if (Physics.SphereCast(ray, RayCaseRadius, out hit, raycastDistance , LayerToDetection))
        {  
        }
        else transform.Translate(direct * currentSpeed * Time.deltaTime, Space.World);
    }


    private void StartDash()
    {
    
        dashTime = Time.time + DashDuration;
        lastDashTime = Time.time;
    }

    private void Dash()
    {
        if (Time.time >= dashTime)
        {
            currentSpeed = moveSpeed;
          
            return;
        }

        currentSpeed = moveSpeed * DashSpeedMultiple;
        //var dashVector = transform.forward * DashSpeed * Time.deltaTime;
        //transform.Translate(dashVector);
    }

    

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

   

}
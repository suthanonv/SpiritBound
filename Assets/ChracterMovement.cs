using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(InputHandler))]
public class ChracterMovement : PlayerMover
{
          float currentSpeed;


    private InputHandler _input;
    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private Camera Camera;

    [SerializeField] public Animator anim;

    Vector3 dashDirect;

    Vector2 input;


    [Header("Dash Detail")]
    [SerializeField] float DashSpeedMultiple = 2;
    [SerializeField] float DashDuration = 0.25f;
    [SerializeField] KeyCode DashKey = KeyCode.LeftShift;
    [SerializeField] float DashCoolDown = 1.5f;
    float lastDashTime;
    float dashTime;

    [Header("Spirit Controller")]
    public bool IsSpirit = false;
    public GameObject player;
    public float maxDistance = 10f;


    private void Start()
    {
        currentSpeed = MovementSpeed;
    }


    // Update is called once per frame
    void Update()
    {

        Dash();

        if (Input.GetKeyDown(DashKey) && Time.time >= lastDashTime + DashCoolDown)
        {
            StartDash();
          
        }



        if (!RotateTowardMouse)
        {

            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            input.Normalize();

            var targetVector = new Vector3(input.x, 0, input.y);

            anim.SetFloat("Speed", input.magnitude);

            var movementVector = MoveTowardTarget(targetVector);
            RotateTowardMovementVector(movementVector);

        }
        if (RotateTowardMouse)
        {
            HandleMovement();
            RotateFromMouseVector();
        }


        if (IsSpirit)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position); //check distance between the spirit and the player
            if (distance > maxDistance)
            {
                Vector3 direction = (transform.position - player.transform.position).normalized;
                transform.position = player.transform.position + direction * maxDistance;
            }

        }
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


        if (Physics.SphereCast(ray, RayCaseRadius, out hit, raycastDistance, LayerToDetection))
        {
        }
        else transform.Translate(direct * currentSpeed * Time.deltaTime, Space.World);
    }

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = currentSpeed * Time.deltaTime;
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;

        transform.position = targetPosition;
        return targetVector;
    }




    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
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
            currentSpeed = MovementSpeed;

            return;
        }

        currentSpeed = MovementSpeed * DashSpeedMultiple;
        //var dashVector = transform.forward * DashSpeed * Time.deltaTime;
        //transform.Translate(dashVector);
    }
}

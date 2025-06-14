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
    [SerializeField] KeyCode DashKey = KeyCode.LeftShift;
    [SerializeField] float DashSpeedMultiple = 5f;
    [SerializeField] float DashCD = 2f;
    [SerializeField] float DashTime = 0.25f;
    [SerializeField] private TrailRenderer _trailRenderer;
    

    bool CanDash = true;
    bool OnDash = false;



    [Header("Spirit Controller")]
    public bool IsSpirit = false;
    public GameObject player;
    public float maxDistance = 10f;
    
    Vector3 movementDirection = Vector3.zero;

    [SerializeField] LayerMask LayerToRayCast;

    private void Start()
    {
        currentSpeed = MovementSpeed;
  
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(DashKey) && CanDash)
        {
            CanDash = false;
            OnDash = true;
            _trailRenderer.emitting = true;
          
            StartCoroutine(OffDash());
        }





        if (!OnDash)
        {
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
     



        }
        else
        {
            MoveChar(transform.forward, DashSpeedMultiple * MovementSpeed);
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
         movementDirection = Vector3.zero;

        Vector3 forwardDirection = transform.forward;

        // Normalize the movement direction to prevent faster diagonal movement
        forwardDirection.Normalize();

        dashDirect = forwardDirection;
        // Handle movement based on WASD keys
        if (Input.GetKey(KeyCode.W))
        {

            MoveChar(forwardDirection , MovementSpeed);
            movementDirection += forwardDirection;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveChar(-forwardDirection , MovementSpeed);
            movementDirection -= forwardDirection;

        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveChar(-transform.right , MovementSpeed);
            movementDirection -= transform.right;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveChar(transform.right , MovementSpeed);
            movementDirection += transform.right;
        }


        anim.SetFloat("Speed", movementDirection.sqrMagnitude);
    }


    public float raycastDistance = 10f;
    [SerializeField] LayerMask LayerToDetection = 0;
    [SerializeField] float RayCaseRadius;
    void MoveChar(Vector3 direct , float Speed)
    {
        Ray ray = new Ray(transform.position, direct);
        RaycastHit hit;




        if (Physics.SphereCast(ray, RayCaseRadius, out hit, raycastDistance, LayerToDetection))
        {
            OnDash = false;
        }
        else transform.Translate(direct * Speed * Time.deltaTime, Space.World);
    }
    private void RotateFromMouseVector()
    {
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world position
        mousePosition.z = Camera.main.transform.position.y - transform.position.y; // This should be the distance from the camera to the player
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);

        // Adjust the target to be at the same height as the player
        target.y = transform.position.y;

        Vector3 direction = target - transform.position;

        // Ensure there's a direction to look at and the distance is greater than a threshold
        if (direction != Vector3.zero && direction.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
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



    IEnumerator OffDash()
    {
        yield return new WaitForSeconds(DashTime);
        OnDash = false;
        _trailRenderer.emitting = false;
        StartCoroutine(ReSetDashCD());
    }


    public void DisableDash()
    {
        OnDash = false;
        CanDash = true;
        _trailRenderer.emitting = false;
    }


    IEnumerator ReSetDashCD()
    {
        yield return new WaitForSeconds(DashCD);
        CanDash = true;

    }
}

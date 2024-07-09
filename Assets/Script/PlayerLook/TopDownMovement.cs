using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowMouse))]
public class TopDownCharacterMover : MonoBehaviour
{
    private FollowMouse _input;

    [SerializeField]
    public bool RotateTowardMouse;

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private Camera Camera;

    
    [SerializeField]
    private float DashSpeed = 1f;
    [SerializeField]
    private float DashDuration = 0.2f;
    [SerializeField]
    private float DashCooldown = 1f;

    private CharacterController _characterController;
    private bool isDashing = false;
    private float dashTime;
    private float lastDashTime;

    private void Awake()
    {
        _input = GetComponent<FollowMouse>();
        _characterController = GetComponent<CharacterController>();
    }

    public void Teleport(Vector3 destination)
    {
        _characterController.enabled = false;
        this.transform.position = destination;
        _characterController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleDashInput();

        if (isDashing)
        {
            Dash();
        }
        else
        {
            var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
            var movementVector = MoveTowardTarget(targetVector);

            if (RotateTowardMouse)
            {
                RotateFromMouseVector();
            }
            else
            {
                RotateTowardMovementVector(movementVector);
            }
        }
    }

    private void HandleDashInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + DashCooldown)
        {
            StartDash();
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
            isDashing = false;
            return;
        }

        var dashVector = transform.forward * DashSpeed * Time.deltaTime;
        _characterController.Move(dashVector);
    }

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
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
}
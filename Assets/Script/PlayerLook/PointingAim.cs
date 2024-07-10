using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PointingAim : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private KeyCode toggleKey;
    [SerializeField] TopDownCharacterMover playerMovement;

    private Camera mainCam;
    private bool isAiming = true; 

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleAiming();
            
        }

        if (isAiming)
        {
            Aim();
        }
    }

    private void ToggleAiming()
    {
        isAiming = !isAiming;

        
        
    }

    private void Aim()
    {

        var (success, position) = GetMousePosition();
        if (success)
        {
            
            var direction = position - transform.position;
            direction.y = 0;
            transform.forward = direction;
            
        }
      
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
}
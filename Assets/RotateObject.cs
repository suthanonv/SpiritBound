using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeedX = 10f;
    public float rotationSpeedY = 30f; // Default speed for Y-axis rotation
    public float rotationSpeedZ = 20f;

    void Update()
    {
        // Rotate the object around its local axes
        transform.Rotate(Vector3.right, rotationSpeedX * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeedZ * Time.deltaTime);
    }
}

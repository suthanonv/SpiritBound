using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCanvasTransform : MonoBehaviour
{
    [SerializeField] Transform EnemiePostion;
    [SerializeField] Vector3 OffSet;
    [SerializeField] Camera MainCam;
    private void Update()
    {
        Vector3 lookAtDirection = MainCam.transform.position - transform.position;

        transform.LookAt(lookAtDirection);
        this.transform.position = EnemiePostion.position + OffSet;
    }
}

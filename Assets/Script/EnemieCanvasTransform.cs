using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemieCanvasTransform : MonoBehaviour
{
    [SerializeField] Transform EnemiePostion;
    [SerializeField] Vector3 OffSet;
    [SerializeField] Camera MainCam;

    [SerializeField] bool IsRotateToCam = true; 

    private void Start()
    {
        MainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        if (EnemiePostion != null) {
            Vector3 lookAtDirection = MainCam.transform.position - transform.position;
       if(IsRotateToCam) transform.LookAt(lookAtDirection);
            this.transform.position = EnemiePostion.position + OffSet;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class CamChange : MonoBehaviour
{
  
    [SerializeField] Camera MainCam;


    public static CamChange instance;

    private void Awake()
    {
        instance = this;
    }


    public void SetCam(Transform CameraPosition)
    {
        //MainCam.transform.position = CameraPosition.transform.position; 
    }

     public void SetCamWithPreSet(CameraPreSetInEachRoom PreSetCam)
    {

    }
}

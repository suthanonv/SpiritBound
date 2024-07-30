using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterActing : MonoBehaviour
{
 [SerializeField] int DoorBranchIndex;
    Transform Player;

    Room DestiantionRoom;


    Camera mainCamera;

    bool IsThisObjectVisible;

    [SerializeField] GameObject Door;
   

    private void Start()
    {

        if (this.TryGetComponent<Collider>(out Collider colldier))
            colldier.enabled = false;
        mainCamera = Camera.main;
      Player = GameObject.FindWithTag("Player").transform;

        DestiantionRoom = RoomDestination.instance.GetRoomDestinationIndex(DoorBranchIndex);
    }


    void Update()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(this.transform.position);

        bool isVisible = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (isVisible)
        {
            IsThisObjectVisible = true;
        }
        else
        {
            IsThisObjectVisible = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DestiantionRoom.SetRoom(Player);
           
        }
    }



    public void OnOpenDoor()
    {
        if (IsThisObjectVisible == false)
        {
            Invoke("StartCamFollow", 0.5f);

        }
        else
        {
            Door.SetActive(true);
            this.GetComponent<Collider>().enabled = true;

        }

    }


    void StartCamFollow()
    {
        SpiritWorld.Instance.EnablePlayer(false);
        CamFollow.instance.player = this.transform;


        Invoke("DoorAnimation", 0.25f);
    }

    void DoorAnimation()
    {
        Door.SetActive(true);
     if(this.TryGetComponent<Collider>(out Collider colldier))
            colldier.enabled = true;


        Invoke("ReSetCam", 1f);
    }


    void ReSetCam()
    {
        CamFollow.instance.player = SpiritWorld.Instance.GetPlayer(SpiritWorld.Instance.playerFormState).transform;
        SpiritWorld.Instance.EnablePlayer(true);
    }


}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterActing : MonoBehaviour
{
 [SerializeField] int DoorBranchIndex;
    Transform Player;

    Room DestiantionRoom;


    private void Start()
    {
      Player = GameObject.FindWithTag("Player").transform;

        DestiantionRoom = RoomDestination.instance.GetRoomDestinationIndex(DoorBranchIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DestiantionRoom.SetRoom(Player);
           
        }
    }
}

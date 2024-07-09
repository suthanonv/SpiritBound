using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnDoor : MonoBehaviour
{
    [SerializeField] Room PreviosRoom;
    Transform Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PreviosRoom.SetRoom(Player);
        }
    }
}

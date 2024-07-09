using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] Transform PlayerSpawnPosition;
    [SerializeField] Transform CameraHolderPositon;
     public void SetRoom(Transform Player)
    {
        Player.GetComponent<PlayerController>().Teleport(PlayerSpawnPosition);

    }

}

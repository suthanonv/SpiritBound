using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using System.Linq;
public class RoomDestination : MonoBehaviour
{
    public static RoomDestination instance;

    [SerializeField] List<RoomBranchList> AllBrachInRoom = new List<RoomBranchList>();

    public Room  RoomThatPlayerin;

    private void Start()
    {
        RoomThatPlayerin.SetRoomInPlayerStage(SpiritWorld.Instance.playerFormState);
    }


    private void Awake()
    {
        instance = this;
    }


    public Room GetRoomDestinationIndex(int BrachIndex)
    {
        RoomBranchList Branch = AllBrachInRoom.FirstOrDefault(i => i.BrachIndex == BrachIndex);

        int RandIndex = Random.Range(0, Branch.RoomInBrach.Count);

        return Branch.RoomInBrach[RandIndex].RoomGameObject;
    }


}

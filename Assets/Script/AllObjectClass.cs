using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum PlayerFormState
{ sprit , physic }

[System.Serializable]
public class AllObjectClass : MonoBehaviour
{
}


[System.Serializable]

public class RoomDetail
{
    public int roomIndex;
    public Room RoomGameObject;
}

[System.Serializable]
public class CameraPreSetInEachRoom
{
    
}
[System.Serializable]
public class RoomBranchList
{
    public int BrachIndex;
    public List<RoomDetail> RoomInBrach = new List<RoomDetail>();
}


[System.Serializable]
public class FormStageComponent
{
    public PlayerFormState formState;

    public List<GameObject> ObjectInFormStage = new List<GameObject>();



}
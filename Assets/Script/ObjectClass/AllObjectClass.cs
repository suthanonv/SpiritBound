using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerFormState
{ sprit , physic , both }

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


[System.Serializable]
public class ListCheck<T>
{
    public List<T> List = new List<T>();

[NonSerialized]    public UnityEvent OnListAddedDelegate = new UnityEvent();
[NonSerialized]    public UnityEvent OnListRemovedDelegate = new UnityEvent();

    public void Add(T ElementToAdd)
    {
        List.Add(ElementToAdd);
        OnListAddedDelegate.Invoke();
    }


    public void Remove(T ElementToAdd)
    {
        List.Remove(ElementToAdd);
        OnListRemovedDelegate.Invoke();
    }
}

[System.Serializable]
public class EnemyWave
{ 
    public ListCheck<GameObject> EnemyInWave = new ListCheck<GameObject>();
    public bool IsHasNewWaveCondition = false;

}
[System.Serializable]
public class PlayerItemSkill
{
    public PlayerFormState PlayerState;
    public UseAbleItemSkill CurrentSkill;
    public UseAbleItem ItemInFormStorage; 
}
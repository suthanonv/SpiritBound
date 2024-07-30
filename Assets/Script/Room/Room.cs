using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.Events;
public class Room : MonoBehaviour
{
    [SerializeField] Transform PlayerSpawnPosition;


    [SerializeField] List<FormStageComponent> ElementInEachForm = new List<FormStageComponent>();



    [SerializeField] GameObject Door;
    [SerializeField] GameObject Chest;

    public List<EnemyWave> EnemyWaveList = new List<EnemyWave>();
    int currentWave = 0;


    [SerializeField] bool IsThisRoomHasClearCondition = false;
    bool ConditionClear = false;
   

    public void RemoveEnemyFromList(GameObject Enemy)
    {
        EnemyWaveList[currentWave].EnemyInWave.Remove(Enemy);
    }
    

    private void Start()
    {
    
        
        

        
        foreach(var i in EnemyWaveList )
        {
            foreach(GameObject x in i.EnemyInWave.List)
            {
                x.GetComponent<EnemyHealth>().RoomThatEnemyInSide = this;
            }
        }

        foreach (EnemyWave i in EnemyWaveList)
        {
            i.EnemyInWave.OnListRemovedDelegate.AddListener(IsThisRoomClear);
        }
        
    }


    public void SetRoom(Transform Player)
    {
        RoomDestination.instance.RoomThatPlayerin = this;
        Player.transform.position = PlayerSpawnPosition.position;

        SetEnemyInWave();

        if (UseAbleItemStorage.instance != null) 
        UseAbleItemStorage.instance.ResetPlayerItemUseingCount();
    }


   
      public void SetRoomInPlayerStage(PlayerFormState CurrentState)
      {
        OpenRoomElement(CurrentState);
        ChangeStateOfAllEnemy(CurrentState);
        if(CurrentState == PlayerFormState.sprit)
        CloseRoomELement(PlayerFormState.physic);
        else
        {
            CloseRoomELement(PlayerFormState.sprit);

        }
    }


    PlayerFormState GetOppositPlayerFormState(PlayerFormState CurrentState)
    {
        if (CurrentState == PlayerFormState.sprit) return PlayerFormState.physic;
        else return PlayerFormState.sprit;
    }


     void OpenRoomElement(PlayerFormState CurrentState)
    {
        List<GameObject> ObjectToOpen = new List<GameObject>();

        FormStageComponent componenet = ElementInEachForm.FirstOrDefault(i => i.formState == CurrentState);


        foreach (GameObject i in componenet.ObjectInFormStage){
         if(i != null) i.SetActive(true);

        }

    }

    void CloseRoomELement(PlayerFormState Opposit)
    {
        List<GameObject> ObjectToClose = new List<GameObject>();

        FormStageComponent componenet = ElementInEachForm.FirstOrDefault(i => i.formState == Opposit);


        foreach (GameObject i in componenet.ObjectInFormStage)
        {
            if(i != null) i.SetActive(false); 
        }
    }

    public void IsThisRoomClear()
    {
        if (EnemyWaveList[currentWave].EnemyInWave.List.Count <= 0)
        {
            if (currentWave >= EnemyWaveList.Count - 1 && (!IsThisRoomHasClearCondition || ConditionClear))
            {
                SetThisRoomClear();
            }
            else if(!IsThisRoomHasClearCondition)
            {

                currentWave++;
                if (EnemyWaveList[currentWave].IsHasNewWaveCondition == false)
                SetEnemyInWave();
            }
        }
        
    }

    public void ChangeStateOfAllEnemy(PlayerFormState playerState)
    {
        if (EnemyWaveList[currentWave].EnemyInWave.List.Count <= 0) return;



        foreach(GameObject i in EnemyWaveList[currentWave].EnemyInWave.List)
        {
          if(i.TryGetComponent<EnemyStateControll>(out EnemyStateControll StateOfEnemy))
                StateOfEnemy.SetEnemyState(playerState);
        }
    }


   public void SetEnemyInWave()
    {
        IsThisRoomClear();
        if (EnemyWaveList.Count == 0)
        { 
            return;
        }
        foreach(GameObject i in EnemyWaveList[currentWave].EnemyInWave.List)
        {
            i.SetActive(true);
        }
        ChangeStateOfAllEnemy(SpiritWorld.Instance.playerFormState);
    }


    public void SetThisRoomClear()
    {
        if (RoomDestination.instance.RoomThatPlayerin != this) return;   
        ConditionClear = true;
        if (Door != null)
            Door.GetComponent<DoorInterActing>().OnOpenDoor();
        if (Chest != null)
            Chest.SetActive(true);
    }
}



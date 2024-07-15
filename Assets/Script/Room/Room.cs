using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;
public class Room : MonoBehaviour
{
    [SerializeField] Transform PlayerSpawnPosition;


    [SerializeField] List<FormStageComponent> ElementInEachForm = new List<FormStageComponent>();



    [SerializeField] GameObject Door;

    public List<EnemyWave> EnemyWaveList = new List<EnemyWave>();
    int currentWave = 0;

    public void RemoveEnemyFromList(GameObject Enemy)
    {
        EnemyWaveList[currentWave].EnemyInWave.Remove(Enemy);
    }
    

    private void Start()
    {
        if (Door != null) 
        Door.SetActive(false);
        SetEnemyInWave();
        foreach (EnemyWave i in EnemyWaveList)
        {
            i.EnemyInWave.OnListRemovedDelegate.AddListener(IsThisRoomClear);
        }
        
    }


    public void SetRoom(Transform Player)
    {
        RoomDestination.instance.RoomThatPlayerin = this;
        Player.transform.position = PlayerSpawnPosition.position;
    }


   
      public void SetRoomInPlayerStage(PlayerFormState CurrentState)
      {
        OpenRoomElement(CurrentState);
        ChangeStateOfAllEnemy(CurrentState);
        CloseRoomELement(GetOppositPlayerFormState(CurrentState));
    }


    PlayerFormState GetOppositPlayerFormState(PlayerFormState CurrentState)
    {
        if (CurrentState == PlayerFormState.sprit) return PlayerFormState.physic;
        else return PlayerFormState.physic;
    }


     void OpenRoomElement(PlayerFormState CurrentState)
    {
        List<GameObject> ObjectToOpen = new List<GameObject>();

        FormStageComponent componenet = ElementInEachForm.FirstOrDefault(i => i.formState == CurrentState);

        if (componenet == null) return;

        foreach (GameObject i in componenet.ObjectInFormStage) i.SetActive(true);

    }

    void CloseRoomELement(PlayerFormState Opposit)
    {
        List<GameObject> ObjectToClose = new List<GameObject>();

        FormStageComponent componenet = ElementInEachForm.FirstOrDefault(i => i.formState == Opposit);

        if (componenet == null) return;

        foreach (GameObject i in componenet.ObjectInFormStage) i.SetActive(false);
    }

    public void IsThisRoomClear()
    {
        if (EnemyWaveList[currentWave].EnemyInWave.List.Count <= 0)
        {
            if (currentWave >= EnemyWaveList.Count -1) Door.SetActive(true);
            else
            {

                currentWave++;
                SetEnemyInWave();
            }
        }
        
    }

    public void ChangeStateOfAllEnemy(PlayerFormState playerState)
    {
        
        foreach(GameObject i in EnemyWaveList[currentWave].EnemyInWave.List)
        {
            i.GetComponent<EnemyStateControll>().SetEnemyState(playerState);
        }
    }


    void SetEnemyInWave()
    {
        if (EnemyWaveList.Count == 0) return;
        foreach(GameObject i in EnemyWaveList[currentWave].EnemyInWave.List)
        {
            i.SetActive(true);
        }
        ChangeStateOfAllEnemy(SpiritWorld.Instance.playerFormState);
    }

}



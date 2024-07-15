using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Room : MonoBehaviour
{
    [SerializeField] Transform PlayerSpawnPosition;


    [SerializeField] List<FormStageComponent> ElementInEachForm = new List<FormStageComponent>();


    public ListCheck<GameObject> EnemyListInRoom = new ListCheck<GameObject>();

    [SerializeField] GameObject Door;
    

    private void Start()
    {
        if (Door != null) 
        Door.SetActive(false);
        EnemyListInRoom.OnListRemovedDelegate.AddListener(IsThisRoomClear);
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
        if (EnemyListInRoom.List.Count <= 0)
        {
            Door.SetActive(true);
        }
        
    }

    public void ChangeStateOfAllEnemy(PlayerFormState playerState)
    {
        
        foreach(GameObject i in EnemyListInRoom.List)
        {
            i.GetComponent<EnemyStateControll>().SetEnemyState(playerState);
        }
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Room : MonoBehaviour
{
    [SerializeField] Transform PlayerSpawnPosition;
    [SerializeField] Transform CameraHolderPositon;

    [SerializeField] List<FormStageComponent> ElementInEachForm = new List<FormStageComponent>();
     public void SetRoom(Transform Player)
    {
        RoomDestination.instance.RoomThatPlayerin = this;
        Player.transform.position = PlayerSpawnPosition.position;
    }


   
    public void SetRoomElement(PlayerFormState CurrentState)
    {
        List<GameObject> ObjectToOpen = new List<GameObject>();

        FormStageComponent componenet = ElementInEachForm.FirstOrDefault(i => i.formState == CurrentState);

        foreach (GameObject i in componenet.ObjectInFormStage) i.SetActive(true);

    }

    public void CloseRoomELement(PlayerFormState Opposit)
    {
        List<GameObject> ObjectToClose = new List<GameObject>();

        FormStageComponent componenet = ElementInEachForm.FirstOrDefault(i => i.formState == Opposit);

        foreach (GameObject i in componenet.ObjectInFormStage) i.SetActive(false);
    }
}



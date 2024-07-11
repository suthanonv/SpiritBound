using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiritWorld : MonoBehaviour
{
    public static SpiritWorld Instance { get; private set; }

    
    public GameObject player;

    private TopDownCharacterMover physicalControl;
    private SpiritController spiritControl;

    public PlayerFormState playerFormState = 0f;

   [SerializeField] GameObject SecondCharacter;

    private float spawnDistance = 1f;

    public GameObject Shader;

    private void Awake()
    {
        Instance = this;

        physicalControl = player.GetComponent<TopDownCharacterMover>();
        spiritControl = player.GetComponent<SpiritController>();


    }


    public GameObject GetPlayer(PlayerFormState EnimeieForm)
    {
        if (playerFormState == PlayerFormState.sprit  && EnimeieForm == PlayerFormState.sprit)
        {
            return SecondCharacter;
        }
        return player;
    }


    public void PlayerState()
    {
        

        ChangePlayerForm(playerFormState);
        RoomDestination.instance.RoomThatPlayerin.SetRoomInPlayerStage(playerFormState);

    }



    void ChangePlayerForm(PlayerFormState state)
    {

        Vector3 playerPos = player.transform.position;
        Vector3 playerDirec = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;

        if (playerFormState == PlayerFormState.sprit)
        {

            Shader.gameObject.SetActive(true);
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<TopDownCharacterMover>().anim.SetFloat("Speed", 0);
            player.GetComponent<TopDownCharacterMover>().enabled = false;
            SecondCharacter.SetActive(true);
            Vector3 spawnPos = playerPos + playerDirec * spawnDistance;
            SecondCharacter.transform.position = spawnPos;
           
            CamFollow.instance.player = SecondCharacter.transform;
        }
        else
        {
            playerFormState = PlayerFormState.physic;
            Shader.gameObject.SetActive(false);

            player.GetComponent<PlayerAttack>().enabled = true;

            player.GetComponent<TopDownCharacterMover>().enabled = true;
            CamFollow.instance.player = player.transform;
            SecondCharacter.SetActive(false);
        }
    }








 
}

    


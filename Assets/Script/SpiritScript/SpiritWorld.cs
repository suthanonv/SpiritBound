using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiritWorld : MonoBehaviour
{
    public static SpiritWorld Instance { get; private set; }

    
    public GameObject player;
    public GameObject spiritPlayer;

    private TopDownCharacterMover physicalControl;
    private SpiritController spiritControl;

    public PlayerFormState playerFormState = 0f;

    GameObject SecondCharacter;

    private float spawnDistance = 1f;

    public GameObject Shader;

    private void Awake()
    {
        Instance = this;

        physicalControl = player.GetComponent<TopDownCharacterMover>();
        spiritControl = player.GetComponent<SpiritController>();


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

            Vector3 spawnPos = playerPos + playerDirec * spawnDistance;
            SecondCharacter = Instantiate(spiritPlayer, spawnPos, playerRotation);
            SecondCharacter.GetComponent<SpiritController>().player = player;
            CamFollow.instance.player = SecondCharacter.transform;
        }
        else
        {
            playerFormState = PlayerFormState.physic;
            Shader.gameObject.SetActive(false);

            player.GetComponent<PlayerAttack>().enabled = true;

            player.GetComponent<TopDownCharacterMover>().enabled = true;
            CamFollow.instance.player = player.transform;
            Destroy(SecondCharacter);
        }
    }








 
}

    


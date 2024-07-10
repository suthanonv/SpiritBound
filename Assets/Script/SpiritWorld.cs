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
 

    private void Awake()
    {
        Instance = this;

        physicalControl = player.GetComponent<TopDownCharacterMover>();
        spiritControl = player.GetComponent<SpiritController>();


    }


    public void PlayerState()
    {
        //Update player position
        Vector3 playerPos = player.transform.position; 
        Vector3 playerDirec = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;

        if (playerFormState == PlayerFormState.physic)
        {
            playerFormState = PlayerFormState.sprit;
            player.GetComponent<TopDownCharacterMover>().enabled = false;

            Vector3 spawnPos = playerPos + playerDirec * spawnDistance;
            SecondCharacter = Instantiate(spiritPlayer, spawnPos, playerRotation);
            CamFollow.instance.player = SecondCharacter.transform;
        }
        else
        {
            playerFormState = PlayerFormState.physic;
            player.GetComponent<TopDownCharacterMover>().enabled = true;
            CamFollow.instance.player = player.transform;
            
            Destroy(SecondCharacter);
        }

      
    }

 
}

    


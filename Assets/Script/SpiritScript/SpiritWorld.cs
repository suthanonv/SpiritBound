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

 public GameObject SecondCharacter;

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


    bool CanChangeForm = true;
    void ChangePlayerForm(PlayerFormState state)
    {
        if (!CanChangeForm) return;

        Vector3 playerPos = player.transform.position;
        Vector3 playerDirec = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;

        if (playerFormState == PlayerFormState.sprit)
        {

            Shader.gameObject.SetActive(true);
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<ChracterMovement>().anim.SetBool("isSleep", true);
            player.GetComponent<ChracterMovement>().enabled = false;
            SecondCharacter.SetActive(true);
            Vector3 spawnPos = playerPos + playerDirec * spawnDistance;
            SecondCharacter.transform.position = spawnPos;
           
            CamFollow.instance.player = SecondCharacter.transform;

            if (SoundEffectManageMent.Instance != null)
            {
                SoundEffectManageMent.Instance.IsEffectEnable(false);
            }
        }
        else
        {
            playerFormState = PlayerFormState.physic;
            Shader.gameObject.SetActive(false);
            player.GetComponent<ChracterMovement>().anim.SetBool("isSleep", false);

            player.GetComponent<PlayerAttack>().enabled = true;

            player.GetComponent<ChracterMovement>().enabled = true;
            CamFollow.instance.player = player.transform;
            SecondCharacter.SetActive(false);

            if (SoundEffectManageMent.Instance != null)
            {
                SoundEffectManageMent.Instance.IsEffectEnable(true);
            }
        }


       
    }




    public void EnablePlayerMovementAndChagneForm(bool Iseanble)
    {
        player.GetComponent<ChracterMovement>().anim.SetBool("isSleep", !Iseanble);

        CanChangeForm = Iseanble;
        SecondCharacter.GetComponent<ChracterMovement>().enabled = Iseanble;
        player.GetComponent<ChracterMovement>().enabled = Iseanble;
    }



 
}

    


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiritForm : MonoBehaviour 
{
    KeyCode input = KeyCode.Space;

    PlayerFormState playerFormState = PlayerFormState.physic;


    public void Start()
    {
        GameObject varGameObject = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
           if(playerFormState == PlayerFormState.physic)
            {
                playerFormState = PlayerFormState.sprit;
                
            }
            else
            {
                playerFormState = PlayerFormState.physic;
                
            }
            SpiritWorld.Instance.playerFormState = playerFormState;
            SpiritWorld.Instance.PlayerState();
         
        }
        
       
      }
}

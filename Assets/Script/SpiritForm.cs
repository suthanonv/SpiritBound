using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiritForm : MonoBehaviour 
{
    KeyCode input = KeyCode.Space;




    public void Start()
    {
        GameObject varGameObject = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SpiritWorld.Instance.PlayerState();
            if(SpiritWorld.Instance.playerFormState == PlayerFormState.physic)
            {
                SpiritWorld.Instance.playerFormState = PlayerFormState.sprit;
            }
            else
            {
                SpiritWorld.Instance.playerFormState = PlayerFormState.physic;
            }
        }
        
       
      }
}

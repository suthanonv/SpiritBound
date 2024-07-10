using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritForm : MonoBehaviour
{
    [SerializeField] KeyCode input;
    public GameObject prefab;
   
    // Update is called once per frame
    
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            
            GetComponent<TopDownCharacterMover>().enabled = false;
            Instantiate(prefab, prefab.transform.position,Quaternion.identity);
        }
       
      }
}

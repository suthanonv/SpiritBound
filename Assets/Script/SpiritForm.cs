using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritForm : MonoBehaviour 
{
    [SerializeField] KeyCode input;
    public GameObject prefab;
    public GameObject varGameObject;

    
    float spawnDistance = 5f;
    Vector3 playerPos;
    Vector3 playerDirec;
    Quaternion playerRotation;

    

    private void Awake()
    {
        playerPos = GameObject.FindWithTag("Player").transform.position;
        playerDirec = GameObject.FindWithTag("Player").transform.forward;
        playerRotation = GameObject.FindWithTag("Player").transform.rotation;
    }
    public void Start()
    {
        GameObject varGameObject = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            
            varGameObject.GetComponent<TopDownCharacterMover>().enabled = false;
            Vector3 spawnPos = playerPos + playerDirec * spawnDistance;
            GameObject SecondCharacter = Instantiate(prefab, spawnPos, playerRotation);
            CamFollow.instance.player = SecondCharacter.transform;
        }
       
      }
}

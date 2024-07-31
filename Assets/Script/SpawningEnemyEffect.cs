using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemyEffect : MonoBehaviour
{

    [SerializeField] GameObject EnemyObject;

    [SerializeField] SpawningEnemyControlling Effect;

    // Update is called once per frame
    void Update()
    {
        if (EnemyObject == null) return;

 
      Effect.GetComponent<MeshRenderer>().enabled = true;
        

        if(EnemyObject.activeSelf)
        {
            if(Effect.IsEnemyAlreadySpawn() == false)
            {
                Effect.gameObject.SetActive(true);
            }
        }
    }
}

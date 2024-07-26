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

        if (EnemyObject.GetComponent<Ai_Controllering>().EnemyForm != SpiritWorld.Instance.playerFormState && EnemyObject.GetComponent<Ai_Controllering>().EnemyForm != PlayerFormState.both)
        {
            Effect.GetComponent<MeshRenderer>().enabled = false;
        }
        else 
        {
            Effect.GetComponent<MeshRenderer>().enabled = true;
        }

        if(EnemyObject.activeSelf)
        {
            if(Effect.IsEnemyAlreadySpawn() == false)
            {
                Effect.gameObject.SetActive(true);
            }
        }
    }
}

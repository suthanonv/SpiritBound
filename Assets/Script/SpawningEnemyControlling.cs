using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemyControlling : MonoBehaviour
{
    [SerializeField] GameObject EnemyGameHolding;


    // Update is called once per frame
    public void SpawningEnemy()
    {
        EnemyGameHolding.SetActive(true);
    }


    public bool IsEnemyAlreadySpawn()
    {
        return EnemyGameHolding.activeSelf;
    }
}

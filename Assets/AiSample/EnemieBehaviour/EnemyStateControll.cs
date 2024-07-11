using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateControll : MonoBehaviour
{
    public GameObject EnemySpiritForm;
    public GameObject EnemyPhisicalForm;

    public void SetEnemyState(PlayerFormState playerState)
    {
        if(playerState == PlayerFormState.physic)
        {
            EnemyPhisicalForm.SetActive(true);
            EnemySpiritForm.SetActive(false);
        }
        else
        {
            EnemySpiritForm.SetActive(true);
            EnemyPhisicalForm.SetActive(false);
        }
    }
}

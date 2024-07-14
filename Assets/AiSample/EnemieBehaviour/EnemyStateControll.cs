using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateControll : MonoBehaviour
{
    [SerializeField] MeterialChange EnemyChangeMaterial;
    [SerializeField] Ai_Controllering FormCheck;

    public void SetEnemyState(PlayerFormState playerState)
    {
        EnemyChangeMaterial.PlayerState = playerState;

        EnemyChangeMaterial.ChangeMeterialCorespondToForm();
    }
}

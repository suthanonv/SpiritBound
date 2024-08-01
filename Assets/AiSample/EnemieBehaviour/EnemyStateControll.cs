using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateControll : MonoBehaviour
{
    [SerializeField] MeterialChange EnemyChangeMaterial;
    [SerializeField] Ai_Controllering FormCheck;
    [SerializeField] GameObject HealthUi;

    public void SetEnemyState(PlayerFormState playerState)
    {
        if(playerState == PlayerFormState.sprit)
        {
          if(this.TryGetComponent<AudioSource>(out AudioSource Audio))
                Audio.bypassEffects = false;
        }
        else
        {
            if (this.TryGetComponent<AudioSource>(out AudioSource Audio))
                Audio.bypassEffects = true;
        }

        if (FormCheck.EnemyForm == PlayerFormState.both)
        {
            HealthUi.SetActive(true);
            return;
        }
        EnemyChangeMaterial.PlayerState = playerState;

        EnemyChangeMaterial.ChangeMeterialCorespondToForm();

        if(HealthUi != null)
        {
            if(playerState != FormCheck.EnemyForm || this.gameObject.activeSelf == false)
            {
                HealthUi.SetActive(false);
            }
            else
            {
                HealthUi.SetActive(true);
            }
        }
    }
}

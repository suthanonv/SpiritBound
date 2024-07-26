using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvokeArea : MonoBehaviour
{
    [SerializeField] Transform FumoPosition;
    [SerializeField] PlayerFormState State;
    private void OnTriggerStay(Collider other)
    {
     
        if(other.gameObject.TryGetComponent<Ai_Controllering>(out Ai_Controllering Ai_Movement))
        {
            if (Ai_Movement.EnemyForm == State || Ai_Movement.EnemyForm == PlayerFormState.both)
            {
                if (!Ai_Movement.isProvoke)
                    Ai_Movement.IsProvoking(true, FumoPosition.gameObject);
            }
        }
    }
}

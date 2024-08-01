using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewindBehavioer : UseAbleItemSkill
{
    bool HaveBeenUseBefore = false;

    GameObject Player;


    [SerializeField] GameObject MarkingPrefabPhysic;
    [SerializeField] GameObject MarkingPreFabSpirit;
    [SerializeField] GameObject DamageEffectArea;
    [SerializeField] GameObject DamageEffectAreaSpirit;
    Transform MarkingPosition;
    Transform PlayerPosition;


    private void Start()
    {
        ResetItemUseingCount();

        if (ItemInPlayerForm == PlayerFormState.sprit)
        {
            PlayerPosition =  SpiritWorld.Instance.SecondCharacter.transform;
        }
        else
        {
            PlayerPosition =  SpiritWorld.Instance.player.transform;
        }
    }

    public override void OnRelesaingKey()
    {
       base.OnRelesaingKey();



        if (!HaveBeenUseBefore)
        {
            ONCD = true;

            if (ItemInPlayerForm == PlayerFormState.physic)
            {
                MarkingPosition = Instantiate(MarkingPrefabPhysic, PlayerPosition.transform.position, Quaternion.identity).transform;

            }
            else
            {
                MarkingPosition = Instantiate(MarkingPreFabSpirit, PlayerPosition.transform.position, Quaternion.identity).transform;
            }



            Invoke("SemiCD", 0.5f);
        }

        else
        {

            if (MarkingPosition != null)
            {
                PlayerPosition.GetComponent<ChracterMovement>().enabled = false;
              
                
                PlayerPosition.transform.position = MarkingPosition.transform.position;
                PlayerPosition.GetComponent<ChracterMovement>().enabled = true;

                if (ItemInPlayerForm == PlayerFormState.physic)
                {
                    GameObject DamageArea = Instantiate(DamageEffectArea, MarkingPosition.transform.position, Quaternion.identity);
                    Destroy(MarkingPosition.gameObject);

                    Destroy(DamageArea, 0.425f);
                }
                else
                {
                    GameObject DamageArea = Instantiate(DamageEffectAreaSpirit, MarkingPosition.transform.position, Quaternion.identity);
                    Destroy(MarkingPosition.gameObject);

                    Destroy(DamageArea, 0.425f);
                }

                HaveBeenUseBefore = false;
                StartItemCD();
            }
        }
        
    }


   

    public override void ResetItemUseingCount()
    {
        HaveBeenUseBefore = false;
        base.ResetItemUseingCount();
    }

    private void SemiCD()
    {
        ONCD = false;
        HaveBeenUseBefore = true;
    }

   
}

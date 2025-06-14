using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UsingUseAbleItem : MonoBehaviour
{
    [SerializeField] KeyCode UsingKey = KeyCode.Mouse1;  
    

    void Update()
    {
        UseAbleItemSkill SkillToUse = UseAbleItemStorage.instance.GetUseAbleItemSKill();

        if (SkillToUse == null || SkillToUse.IsSkillOnCD() == true) return;

        if(Input.GetKey(UsingKey))
        {
            SkillToUse.OnHoldingKey();
        }

        if(Input.GetKeyUp(UsingKey))
        {
            SkillToUse.OnRelesaingKey();
        }
    }
}

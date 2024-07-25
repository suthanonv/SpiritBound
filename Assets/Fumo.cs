using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fumo : MonoBehaviour
{
    [SerializeField] MeterialChange Meterial;

    [SerializeField] Collider ProvokeColiider;

           public List<GameObject> ProvokedEnemyList = new List<GameObject>();

    [SerializeField] float SkillTime = 5;
    public void IsHolding(bool Holding)
    {
        ProvokeColiider.enabled = false;
        if (Holding)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            Meterial.OnMaterialFade();
        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            Meterial.NormleMaterial();
            StartActive();
        }
    }


    void StartActive()
    {
        ProvokeColiider.enabled = true;

        Invoke("DisActivateSkill", SkillTime);
    }

    void DisActivateSkill()
    {
        ProvokeColiider.enabled = false;

        foreach (GameObject i in ProvokedEnemyList)
        {
            if (i != null)
            {
             i.GetComponent<Ai_Controllering>().IsProvoking(false, this.gameObject);
            }
        }

        this.gameObject.SetActive(false);

    }
}

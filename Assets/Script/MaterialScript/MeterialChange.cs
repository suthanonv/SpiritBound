using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class MeterialChange : MonoBehaviour
{
    public MeshRenderer[] ModelPart;


   

    [Header("Hiting Effect")]
    [SerializeField] float HitChageperiod;



    [Header("Material")]
    [SerializeField] Material OnHit;
    [SerializeField] Material OffHit;



    [Header("Show Material Before Attack")]
    [SerializeField] Ai_Controllering FormCheck;
    [NonSerialized]   public PlayerFormState PlayerState;
    [SerializeField] Material FadeMaterial;

    public void OnHitMeterial()
    {

        StopAllCoroutines();

        foreach (MeshRenderer i in ModelPart)
        {

            i.GetComponent<Renderer>().material = OffHit;
        }

        StartCoroutine(ChangeHitingColor());
    }


    public void ChangeMeterialCorespondToForm()
    {
        StopAllCoroutines();
        NormleMaterial();
        if (PlayerState == FormCheck.EnemyForm)
        {
            OnMeterial();
        }
        else
        {
            OffMeterial();
        }
    }

     void OffMeterial()
    {
       
        foreach (MeshRenderer i in ModelPart)
        {

            i.GetComponent<MeshRenderer>().enabled = false;
        }
    }

     void OnMeterial()
    {
        foreach (MeshRenderer i in ModelPart)
        {

            i.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void OnMaterialFade()
    {
        foreach (MeshRenderer i in ModelPart)
        {

            i.GetComponent<Renderer>().material = FadeMaterial;
        }
    }


   public void OnMaterialShowingBeforeHit()
    {
        OnMeterial();
        if (PlayerState != FormCheck.EnemyForm)
        {
            OnMaterialFade();
        }
    }

 
     void NormleMaterial()
    {
        foreach (MeshRenderer i in ModelPart)
        {


            i.GetComponent<Renderer>().material = OffHit;


        }
    }


    IEnumerator ChangeHitingColor()
    {

       
        foreach (MeshRenderer i in ModelPart)
        {


            i.GetComponent<Renderer>().material = OnHit;


        }

        yield return new WaitForSeconds(HitChageperiod);


        NormleMaterial();
    }
}

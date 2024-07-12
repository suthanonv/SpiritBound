using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MeterialChange : MonoBehaviour
{
    public MeshRenderer[] ModelPart;
    [SerializeField] float HitChageperiod;
    [SerializeField] Material OnHit;
    [SerializeField] Material OffHit;

    public void OnHitMeterial()
    {

        StopAllCoroutines();

        foreach (MeshRenderer i in ModelPart)
        {

            i.GetComponent<Renderer>().material = OffHit;
        }

        StartCoroutine(ChangeHitingColor());


    }

    IEnumerator ChangeHitingColor()
    {

       
        foreach (MeshRenderer i in ModelPart)
        {


            i.GetComponent<Renderer>().material = OnHit;
            Debug.Log(i.material.GetColor("_EmissionColor"));


        }

        yield return new WaitForSeconds(HitChageperiod);


        foreach (MeshRenderer i in ModelPart)
        {

            i.GetComponent<Renderer>().material = OffHit;


        }
    }
}

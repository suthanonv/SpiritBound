using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MeterialChange : MonoBehaviour
{
    [SerializeField] List<GameObject> ModelPart = new List<GameObject>();
    [SerializeField] float HitChageperiod;

    public void OnHitMeterial()
    {

        StopAllCoroutines();


        foreach (GameObject i in ModelPart)
        {

          i.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
        }
        StartCoroutine(ChangeHitingColor());


    }

    IEnumerator ChangeHitingColor()
    {
        foreach (GameObject i in ModelPart)
        {

            i.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
        }

        yield return new WaitForSeconds(HitChageperiod);

        foreach (GameObject i in ModelPart)
        {

            i.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
        }
    }
}

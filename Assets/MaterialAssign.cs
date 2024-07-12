using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


[ExecuteInEditMode]
public class MaterialAssign : MonoBehaviour
{

    MeterialChange SetMeterial;

    void Awake()
    {
        SetMeterial = GetComponent<MeterialChange>();
    }

    private void Start()
    {
        MeshRenderer[] AllChild = GetComponentsInChildren<MeshRenderer>();

        SetMeterial.ModelPart = AllChild;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNewItem : MonoBehaviour
{
    public static PickUpNewItem instance;

    private void Awake()
    {
        instance = this;
    }

    public void GettingNewItem(UseAbleItem Item)
    {

    }
}

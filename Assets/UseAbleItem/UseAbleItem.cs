using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class UseAbleItem : ScriptableObject
{
    public string ItemName = "none";

    public Sprite SpriteIcon;

    public string ItemDescription = "";

    public UseAbleItemSkill ItemSkill;

    [Header("Item Stat")]

    public int UsingLimitPerRoom = -1;
    public float CDTime = -1;
   
}

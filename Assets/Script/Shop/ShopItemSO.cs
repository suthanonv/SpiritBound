using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ScriptableObjects/ShopItems", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
}

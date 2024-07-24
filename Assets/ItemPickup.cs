using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] UseAbleItem ItemStat;

    [SerializeField] GameObject E_ButtonUI;
    [SerializeField] GameObject ItemPareantHolder;
    float PickUPRadius = 4;
    Transform Player;


    KeyCode PickUpKey = KeyCode.E;
    void Start()
    {
        Player = SpiritWorld.Instance.GetPlayer(PlayerFormState.physic).transform;   
    }

    // Update is called once per frame
    void Update()
    {
        bool IsInRadius = Vector3.Distance(this.transform.position, Player.transform.position) <= PickUPRadius;


        E_ButtonUI.SetActive(IsInRadius);

        if (Input.GetKeyDown(PickUpKey) && IsInRadius) LoadingItem();
    }


    void LoadingItem()
    {
        Destroy(ItemPareantHolder);
    }
}

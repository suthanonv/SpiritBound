using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellingManageMent : MonoBehaviour
{
    [SerializeField] float InterActiveRange = 10f;

    [SerializeField] Transform ItemHolder;
    [SerializeField] Transform ShopCheckingPositon;
    GameObject TarGetItem;
    void Update()
    {
        if(Vector3.Distance(SpiritWorld.Instance.player.transform.position, ShopCheckingPositon.transform.position) <= InterActiveRange)
        {
            if(ItemHolder.childCount > 0)
            {
                 TarGetItem = CloseedItem();

                TarGetItem.GetComponent<ItemSelling>().OnSelteced(true);



                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Key Pressed");
                    TarGetItem.GetComponent<ItemSelling>().OnBuyed();
                }
            }
        }
    }


    GameObject CloseedItem()
    {
        float PreviosDistance = 15;

        GameObject ClosedObject = null;
       
        foreach(Transform i in ItemHolder)
        {
            float Distance = Vector3.Distance(SpiritWorld.Instance.player.transform.position, i.position);

            if (Distance < PreviosDistance)
            {
                PreviosDistance = Distance;
                ClosedObject = i.gameObject;
            }
            }

        if(ClosedObject != TarGetItem && TarGetItem != null)
        {

            TarGetItem.GetComponent<ItemSelling>().OnSelteced(false);
        }


            return ClosedObject;
    }
}

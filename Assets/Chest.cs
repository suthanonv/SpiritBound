using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] List<GameObject> ItemToDropList = new List<GameObject>();

    [SerializeField] float InterActingRange = 5;

    [SerializeField] GameObject UiButtonHolder;
    [SerializeField] GameObject UiButtonClick;

    [SerializeField] Transform ItemSpawningPoint;

    KeyCode InterActingKey = KeyCode.E;



    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, SpiritWorld.Instance.player.transform.position) <= InterActingRange)
        {
            UiButtonClick.SetActive(true);
            if (Input.GetKeyDown(InterActingKey))
            {
                UiButtonHolder.SetActive(false);
                this.GetComponent<Animator>().SetTrigger("Open");
            }
        }
    }

    public void SpawningItem()
    {
        int indexToSpawn = Random.Range(0 , ItemToDropList.Count);

        Instantiate(ItemToDropList[indexToSpawn], ItemSpawningPoint.transform.position, Quaternion.identity);
    }
}

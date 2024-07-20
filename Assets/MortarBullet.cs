using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBullet : MonoBehaviour
{
    [SerializeField] GameObject Nuke;
    [SerializeField] Transform NukeSpawnPoint;


    public void SpawingNuke()
    {
        Instantiate(Nuke, NukeSpawnPoint.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

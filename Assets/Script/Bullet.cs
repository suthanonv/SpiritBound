using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float BulletTIme;
    void Start()
    {
        Destroy(gameObject, BulletTIme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

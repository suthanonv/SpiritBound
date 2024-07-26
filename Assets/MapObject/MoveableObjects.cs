using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    //This script is for moveobjects in the maps
    [SerializeField] float speed = 5f;
    [SerializeField] float destroyDelay = 5f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
    private IEnumerator DestroyAfterDelay() 
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    
}

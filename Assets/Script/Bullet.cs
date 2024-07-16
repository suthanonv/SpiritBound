using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float BulletTIme;
    [SerializeField] float ShowingRange;
    [SerializeField] float Daamge;

    [SerializeField] PlayerFormState BullletForm = PlayerFormState.sprit;

    [Header("Material")]
    [SerializeField] Material DefaultMaterial;
    [SerializeField] Material FadingMaterial;
    void Start()
    {
        Destroy(gameObject, BulletTIme);
    }

    // Update is called once per frame
    void Update()
    {
        if(BullletForm != SpiritWorld.Instance.playerFormState)
        {
            if(Vector3.Distance(this.transform.position, SpiritWorld.Instance.player.transform.position) <= ShowingRange)
            {
                this.GetComponent<MeshRenderer>().enabled = true;
                this.GetComponent<Renderer>().material = FadingMaterial;
            }
            else
            {
                this.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<Renderer>().material = DefaultMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(Daamge);
            Destroy(this.gameObject); 
        }
    }
}

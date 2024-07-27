using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public virtual void PlayeringSound()
    {
      this.GetComponent<AudioSource>().Play();
    }

    public virtual void EnableEffect(bool Enable)
    {
        GetComponent<AudioSource>().bypassEffects = Enable;
    }

    public void StopplaySound()
    {
        this.GetComponent<AudioSource>().Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public virtual void PlayeringSound()
    {

    }

    public virtual void EnableEffect(bool Enable)
    {
        GetComponent<AudioSource>().bypassEffects = Enable;
    }
}

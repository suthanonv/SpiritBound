using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlashingSound : Sound
{
  [NonSerialized]  public int SoundIndex = 0;

 [SerializeField]   List<AudioClip> SwordComboSound = new List<AudioClip>();

    AudioSource AudioSource;
    
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public override void PlayeringSound()
    {
        SoundIndex -= 1;
        AudioSource.clip = SwordComboSound[SoundIndex];

        AudioSource.Play();
    }


   
}

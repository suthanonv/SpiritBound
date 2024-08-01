using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicSound : Sound
{
    [SerializeField] List<MusicList> MusicToPlayList = new List<MusicList>();


    string CurrentMusic = "";

    public void PlayingMusic(string Name)
    {

        if (CurrentMusic == Name) return;
        CurrentMusic = Name;



       AudioClip MusicToplay = MusicToPlayList.FirstOrDefault(i => i.MusicName == Name).Music;

     AudioSource Source = GetComponent<AudioSource>();

        Source.clip = MusicToplay;
        Source.Play();

        
    }
}

[System.Serializable]
public class MusicList
{
    public string MusicName;
    public AudioClip Music;
}

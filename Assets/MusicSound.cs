using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicSound : Sound
{
    [SerializeField] List<MusicList> MusicToPlayList = new List<MusicList>();



    private void Start()
    {
        PlayingMusic("Combat");
    }
    public void PlayingMusic(string Name)
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SoundEffectManageMent : MonoBehaviour
{
    public static SoundEffectManageMent Instance;

    private void Awake()
    {
        Instance = this;
    }

   [SerializeField] List<GetSoundScript> soundScripted = new List<GetSoundScript>();
   

    public Sound GetSoundScripting(string scriptName)
    {
        return soundScripted.FirstOrDefault(i => scriptName == i.name).SoundScript;
    }



    public void IsEffectEnable(bool IsEnable)
    {
        foreach(GetSoundScript i in soundScripted)
        {
            i.SoundScript.EnableEffect(IsEnable);
        }
    }


}

[System.Serializable]
public class GetSoundScript
{
  public  string name =  "none";
    public Sound SoundScript;
}


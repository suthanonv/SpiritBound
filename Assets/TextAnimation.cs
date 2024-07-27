using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;
using UnityEngine.SceneManagement;
public class TextAnimation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;

    [SerializeField] string SceneNameToLoad = "";


  [SerializeField]  List<StringTextAnimatedLists> stringTextAnimatedLists = new List<StringTextAnimatedLists>();


    int CurrentIndex = 0;

    void Update()
    {
        if(CurrentIndex < stringTextAnimatedLists.Count)
        {
            if (!stringTextAnimatedLists[CurrentIndex].IsStart)
            {
                StartCoroutine(stringTextAnimatedLists[CurrentIndex].TextAnimation(Text));
            }

            if(stringTextAnimatedLists[CurrentIndex].IsAnimationEnd() == true)
            {
                CurrentIndex++;
            }
        }
        else
        {
            if(SceneNameToLoad != "")
            SceneManager.LoadScene(SceneNameToLoad);
        }
     
    }
}

[System.Serializable]
public class StringTextAnimatedLists
{
     Color TextStartColor = Color.white;
    public Color TextEndColor = Color.white;

    public float NextTextCD = 0.5f;
    public string TextAnimationToPlay;
    public int DotLoopCount;
    public float TextDelay = 0.25f;


    [NonSerialized] public bool IsStart = false;

    bool AnimatedEnd = false;
    public bool IsAnimationEnd()
    {
        return AnimatedEnd;
    }


    TextMeshProUGUI textToSet;

   public IEnumerator TextAnimation(TextMeshProUGUI Text )
    {
        Text.color = TextStartColor;
        textToSet = Text;

        IsStart = true;
        string DisPlayText = "";
      
        
        int CurrentTextIndex = 0;
        int DotLoopCountcurrentCount = 0;


   
        int IndexOfDot = TextAnimationToPlay.IndexOf(".");

        string StringWithOutDot = "";
        if (IndexOfDot > -1)
        {
             StringWithOutDot = TextAnimationToPlay.Substring(0, IndexOfDot);
        }

        while (DisPlayText.Length < TextAnimationToPlay.Length || DotLoopCountcurrentCount < DotLoopCount)
        {
           
            if(CurrentTextIndex >= TextAnimationToPlay.Length)
            {
                DisPlayText = StringWithOutDot;
                CurrentTextIndex = IndexOfDot;
                Text.text = DisPlayText;
                yield return new WaitForSeconds(TextDelay);
                DotLoopCountcurrentCount++;
            }

            DisPlayText += TextAnimationToPlay[CurrentTextIndex];
            Text.text = DisPlayText;

            CurrentTextIndex++;


          yield return new WaitForSeconds(TextDelay);
          
        }

        textToSet.color = TextEndColor;
        yield return new WaitForSeconds(NextTextCD);
        AnimatedEnd = true;


    }
}

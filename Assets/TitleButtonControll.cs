using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class TitleButtonControll : MonoBehaviour
{

    enum ButtonStat
    { none , start , exit}


    ButtonStat currentButtonStat = ButtonStat.none;

    float CD = 0.1f;
    int CurrentCD = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            if(CurrentCD == 0)
            {
                CurrentCD = 1;

                switch (currentButtonStat)
                { 
                case ButtonStat.none : this.GetComponent<Animator>().SetTrigger("ONStartSelect");
                            
                            return;
                    case ButtonStat.start: this.GetComponent<Animator>().SetTrigger("ExitSelect"); return;
                        case ButtonStat.exit: this.GetComponent<Animator>().SetTrigger("ONStartSelect");  return;
                }
                Invoke("Cooldown", CD);
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
    }


    void Cooldown()
    {
        CurrentCD = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleButtonControll : MonoBehaviour
{
    [SerializeField] string SceneToLoadName;

    enum ButtonStat
    { none, start, exit }


    ButtonStat currentButtonStat = ButtonStat.none;

    float CD = 0.1f;
    int CurrentCD = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurrentCD == 0)
            {
                CurrentCD = 1;

                switch (currentButtonStat)
                {
                    case ButtonStat.none:
                        this.GetComponent<Animator>().SetTrigger("ONStartSelect") ;
                        currentButtonStat = ButtonStat.start;
                        return;
                    case ButtonStat.start: this.GetComponent<Animator>().SetTrigger("ExitSelect"); currentButtonStat = ButtonStat.exit; return;
                    case ButtonStat.exit: this.GetComponent<Animator>().SetTrigger("ONStartSelect"); currentButtonStat = ButtonStat.start; return;
                }
                Invoke("Cooldown", CD);
            }
        }


        bool isRun = false;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isRun)
        {
            if (currentButtonStat == ButtonStat.start)
            {
                isRun = true;

                this.GetComponent<Animator>().SetTrigger("Selected");
            }

            if (currentButtonStat == ButtonStat.exit)
            {
                Application.Quit();
            }
        }



    }
    void Cooldown()
    {
        CurrentCD = 0;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoadName);
    }
}

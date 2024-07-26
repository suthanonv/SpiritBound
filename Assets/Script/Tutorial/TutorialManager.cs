using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image W;
    public Image A;
    public Image S;
    public Image D;
    public Image Shift;
    public Image SpaceBar;

    private bool wActive = true;
    private bool aActive = true;
    private bool sActive = true;
    private bool dActive = true;
    private bool shiftActive = false;
    private bool spaceActive = false; // not using yett

    private int keysPressed = 0;

    [SerializeField] float hideDelay = 1f;

    void Start()
    {
        Shift.gameObject.SetActive(false);
    
     //   SpaceBar.gameObject.SetActive(false);
    }

    void Update()
    {
        if (wActive && Input.GetKeyDown(KeyCode.W))
        {
            wActive = false;
            StartCoroutine(hideImageDelay(W));
        

        }
        if (aActive && Input.GetKeyDown(KeyCode.A))
        {
            aActive = false;
            StartCoroutine(hideImageDelay(A));
           

        }
        if (sActive && Input.GetKeyDown(KeyCode.S))
        {
            sActive = false;
            StartCoroutine(hideImageDelay(S));
          

        }
        if (dActive && Input.GetKeyDown(KeyCode.D))
        {
              dActive = false;
            StartCoroutine(hideImageDelay(D));
       

        }
        if (shiftActive && Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            StartCoroutine(hideImageDelay(Shift));
           

        }
        //if (spaceActive && Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(hideImageDelay(SpaceBar));
        //    spaceActive = false;

        //}

    }

    IEnumerator hideImageDelay(Image image) 
    {
        yield return new WaitForSeconds(hideDelay);
        image.gameObject.SetActive(false);
        keysPressed++;
        if (keysPressed == 4 && !shiftActive) //All WASD been pressed
        {
            ShowShiftButton();
        }

    }
    void ShowShiftButton()
    {
        Debug.Log("Shift Button");
        Shift.gameObject.SetActive(true);
        shiftActive = true;
    }
    public void HideShiftButton()
    {
        Debug.Log("Hiding Shift Button");
        Shift.gameObject.SetActive(false); 
    }

}

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
    private bool spaceActive = false;

    private int keysPressed = 0;

    [SerializeField] float hideDelay = 1f;

    void Start()
    {
        Shift.gameObject.SetActive(false);
        SpaceBar.gameObject.SetActive(false);
    }

    void Update()
    {
        if (wActive && Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(hideImageDelay(W));
            wActive = false;

        }
        if (aActive && Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(hideImageDelay(A));
            aActive = false;

        }
        if (sActive && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(hideImageDelay(S));
            sActive = false;

        }
        if (dActive && Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(hideImageDelay(D));
            dActive = false;

        }
        if (shiftActive && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(hideImageDelay(Shift));
            shiftActive = false;

        }
        if (spaceActive && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(hideImageDelay(Shift));
            shiftActive = false;

        }

    }

    IEnumerator hideImageDelay(Image image) 
    {
        yield return new WaitForSeconds(hideDelay);
        image.gameObject.SetActive(false);
        keysPressed++;
        if (keysPressed >= 4 && !shiftActive) //All WASD been pressed
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

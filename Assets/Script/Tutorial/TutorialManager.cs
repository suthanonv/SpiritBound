using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;
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

    public static TutorialManager instance;

    [SerializeField] List<GameObject> Enemy;


    [SerializeField] UnityEvent OnTutorialEnd;

    [SerializeField] UnityEvent OnClickSpaceBar;
   


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Shift.gameObject.SetActive(false);
    
        SpaceBar.gameObject.SetActive(false);

        OnTutorialEnd.AddListener(RoomDestination.instance.RoomThatPlayerin.SetThisRoomClear);
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
            shiftActive = false;
            StartCoroutine(hideImageDelay(Shift));

            OnTutorialEnd.Invoke();

        }
        if (spaceActive && Input.GetKeyDown(KeyCode.Space))
        {
            spaceActive = false;
            StartCoroutine(hideImageDelay(SpaceBar));

            OnClickSpaceBar.Invoke();
        }

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
    public void ShowSpaceButton()
    {
        Debug.Log("ShowSpace");
        SpaceBar.gameObject.SetActive(true);
        spaceActive = true;
    }
 


}

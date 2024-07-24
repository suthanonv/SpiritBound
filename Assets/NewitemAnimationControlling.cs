using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewitemAnimationControlling : MonoBehaviour
{
    [SerializeField] Animator NewItemBoarderAnimation;
    [SerializeField] RectTransform NewItemBoarder;
    [SerializeField] RectTransform NewItemOriginPosition;



    public static NewitemAnimationControlling instance;


    [Header("Animation")]

    [SerializeField] Animator PhysicPcBuddyAnimation;
    [SerializeField] Animator SpiritBuddyAnimation;

    private void Awake()
    {
        instance = this;
    }

    float MoveSpeed = 5;



    Transform MoveToPositon = null;




    private void Start()
    {
        NewItemBoarder.anchoredPosition = NewItemOriginPosition.anchoredPosition;
    }

    public void MoveOverHeadAnimation(RectTransform MoveTo , PlayerFormState StateOfItemThatMOuseOver)
    {
      

       StartCoroutine( MoveRectTransform(NewItemBoarder, MoveTo , 0.1f));

        if (StateOfItemThatMOuseOver == PlayerFormState.physic)
        {

            NewItemBoarderAnimation.SetTrigger("OnPhysicOverHead");
            SpiritBuddyAnimation.SetBool("IsOnPoiting", false);
            PhysicPcBuddyAnimation.SetBool("IsOnPoiting", true);

        }
        else
        {
            PhysicPcBuddyAnimation.SetBool("IsOnPoiting", false);
            SpiritBuddyAnimation.SetBool("IsOnPoiting", true);


            NewItemBoarderAnimation.SetTrigger("OnSpiritOverHead");
        }
    }


    private System.Collections.IEnumerator MoveRectTransform(RectTransform from, RectTransform to, float duration)
    {
        Vector2 startPos = from.anchoredPosition;
        Vector2 endPos = to.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            from.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        from.anchoredPosition = endPos;
    }

}

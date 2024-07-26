using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseOverUI : MonoBehaviour
{
    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;
    public GameObject targetUIElement;

    [SerializeField] Animator PcBuddyAnim;

    [SerializeField] RectTransform OverHeadPosition;
    [SerializeField] PlayerFormState ItemStorageForm;


    void Update()
    {

        if (IsPointerOverUIElement(this.gameObject))
        {
            NewitemAnimationControlling.instance.MoveOverHeadAnimation(OverHeadPosition, ItemStorageForm);
        }
      
    }

    private bool IsPointerOverUIElement(GameObject uiElement)
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == uiElement)
            {
                return true;
            }
        }
        return false;
    }
}


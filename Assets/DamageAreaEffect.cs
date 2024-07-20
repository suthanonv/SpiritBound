using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class DamageAreaEffect : MonoBehaviour
{
    [SerializeField] float TimeToFullTheCircle = 2f;
    [SerializeField] Transform ShowingCircleArea;
        float ScaleXZ = 0;

    private float timer = 0f;
    private float currentValue = 0f;

    public UnityEvent OnCircleEnd;
    
    
    private void OnEnable()
    {
        StartCoroutine(CircleAnimation());
    }







    IEnumerator CircleAnimation()
    {
        while (timer < TimeToFullTheCircle)
        {
            timer += Time.deltaTime;
            currentValue = timer / TimeToFullTheCircle;

            ShowingCircleArea.localScale = new Vector3(currentValue, 1, currentValue);

            yield return null;
        }

        currentValue = 1f; // Ensure currentValue is exactly 1 at the end
        OnCircleEnd.Invoke();
        ShowingCircleArea.localScale = new Vector3(currentValue, 1, currentValue);
        
    }

  
}

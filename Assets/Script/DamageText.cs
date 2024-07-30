using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    float TextShowingTime = 0.25f;


    Coroutine DisableTextCorou;
    void Start()
    {

    }

    public void SetDamageText(float DamageToset)
    { 
        text.gameObject.SetActive(true);
        DamageToset = Mathf.RoundToInt(DamageToset);
        text.text = DamageToset.ToString();

        if(DisableTextCorou != null) StopCoroutine(DisableTextCorou);

        if(this.gameObject.activeSelf == true)
        DisableTextCorou = StartCoroutine(DisableText());

    }



    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(TextShowingTime);

        if (text.gameObject != null)
            text.gameObject.SetActive(false);
        else Destroy(this.gameObject);
    }


}

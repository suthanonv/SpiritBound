
using UnityEngine;
using UnityEngine.UI;
public class HealthBarAnimation : MonoBehaviour
{
    [SerializeField] Slider BaseHealthBar;
    [SerializeField] Slider DecreaseingHealthBar;
    [SerializeField] float LerpSpeed = 2;
    float NumToLerpTo = 0;

    bool OnLerping = false;

    public void SetHealthBar(float MaxHealht , float CurrnetHealth)
    {
        BaseHealthBar.maxValue = MaxHealht;
        DecreaseingHealthBar.maxValue = MaxHealht;
        BaseHealthBar.value = CurrnetHealth;
        DecreaseingHealthBar.value = CurrnetHealth;
    }

     public void HealthBarRunAnimation(float CurrnetHealth , float PrevioslyHealth)
    {
        BaseHealthBar.value = CurrnetHealth;
        NumToLerpTo = CurrnetHealth;
        DecreaseingHealthBar.value = PrevioslyHealth;
        OnLerping = true;
    }

    private void Update()
    {
        if (OnLerping)
        {
            DecreaseingHealthBar.value = Mathf.Lerp(DecreaseingHealthBar.value, NumToLerpTo -1, Time.deltaTime * LerpSpeed);

            if (DecreaseingHealthBar.value <= NumToLerpTo)
            {
                DecreaseingHealthBar.value = NumToLerpTo;
            }
        }

    }
}

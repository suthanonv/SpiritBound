using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{
    public static PlayerHealth instance;


    [SerializeField] HealthBarAnimation HealthBar;

    [SerializeField] GameObject HittingEffect;

    GameObject PlayerObjectThatGotHitted;

    [SerializeField] GameObject DeathEffect;

    private void Awake()
    {
        
        instance = this;
    }
    private void Start()
    {
        HealthBar.SetHealthBar(MaxHealth, currenthealth);
    }

    public void SetPlayerHittedObject(GameObject HittedObject)
    {
        PlayerObjectThatGotHitted = HittedObject;
    }


    public bool IsDeath(float Damage)
    {
        if (currenthealth - Damage > 0) return false;
        return true;
    }

    public override void TakeDamage(float Damage)
    {
        float previosHealth = currenthealth;


        if (currenthealth - Damage > 0)
        {
            currenthealth -= Damage;
            SoundEffectManageMent.Instance.GetSoundScripting("PlayerHitted").PlayeringSound();
            HealthBar.HealthBarRunAnimation(currenthealth, previosHealth);

            HittingEffect.SetActive(true);

            Invoke("OffHittingEffect", 0.171f);

        }
        else
        {
            currenthealth -= Damage;
            HealthBar.HealthBarRunAnimation(currenthealth, previosHealth);
            
          if(!AlreadyDeath)
            Died();
        }


        
    }

    public void Healing(float HealingAmount)
    {
        if (currenthealth + HealingAmount > MaxHealth) currenthealth = MaxHealth;
        else currenthealth += HealingAmount;

        HealthBar.HealthBarRunAnimation(currenthealth, currenthealth);

    }
    bool AlreadyDeath = false;
    public override void Died()
    {
        AlreadyDeath = true;
        CamFollow.instance.player = PlayerObjectThatGotHitted.transform;

        SpiritWorld.Instance.player.GetComponent<ChracterMovement>().enabled = false;
        SpiritWorld.Instance.player.GetComponent<ChracterMovement>().anim.SetBool("isSleep", true);
        SpiritWorld.Instance.player.GetComponent<PlayerAttack>().enabled = false;

        SpiritWorld.Instance.SecondCharacter.GetComponent<ChracterMovement>().enabled = false;
        SpiritWorld.Instance.SecondCharacter.GetComponent<ChracterMovement>().anim.SetBool("isSleep", true);
        SpiritWorld.Instance.SecondCharacter.GetComponent<PlayerAttack>().enabled = false;

    

        Invoke("StartTimeScale", 0.1f);
    }


    void StartTimeScale()
    {
        SoundEffectManageMent.Instance.GetSoundScripting("PlayerHitted").PlayeringSound();
       
        Time.timeScale = 0.01f;
        Invoke("ReSetTimeScale", 1f * Time.timeScale);
        Invoke("StartDeathEffect", 0.125f * Time.timeScale);
    }

    public void ReSetTimeScale()
    {
       
        Time.timeScale = 1;
        SceneManager.LoadScene("DeathScene");
    }

    public void StartDeathEffect()
    {
        DeathEffect.SetActive(true);
    }



    public void OffHittingEffect()
    {
        SoundEffectManageMent.Instance.GetSoundScripting("PlayerHitted").StopplaySound();
        HittingEffect.SetActive(false);
    }
}

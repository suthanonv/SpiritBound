using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimat : MonoBehaviour
{
    [SerializeField] MortarAnimatControll animC;
    [SerializeField] Animator Mortaranim;
   public void OnFinishAnim()
    {
        Mortaranim.SetBool("OnAnimationFinish", true);
        animC.Shooting();
        
        this.gameObject.SetActive(false);
    }
}

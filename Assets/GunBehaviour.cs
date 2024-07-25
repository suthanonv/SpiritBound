using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : UseAbleItemSkill
{
    [SerializeField] Rigidbody PhysicBullets;
    [SerializeField] Rigidbody SpiritBullet;
    [SerializeField] Transform ShootingDiretion;
    Transform ShootingDirect;
    [SerializeField] Vector3 ShootingOffSet;

    [SerializeField] float BulletForceSpeed = 25;

    GameObject PlayerForm;
    private void Start()
    {
        if (ItemInPlayerForm == PlayerFormState.sprit)
        {
            ShootingDirect = Instantiate(ShootingDiretion, SpiritWorld.Instance.SecondCharacter.transform);
        }
        else
        {
            ShootingDirect = Instantiate(ShootingDiretion, SpiritWorld.Instance.player.transform);
        }
     
        ShootingDirect.position += ShootingOffSet;
        ResetItemUseingCount();
    }




    public override void OnHoldingKey()
    {
        base.OnRelesaingKey();
    }


    public override void OnRelesaingKey()
    {
        
         PlayerForm = SpiritWorld.Instance.GetPlayer(ItemInPlayerForm);   

          if(ItemInPlayerForm == PlayerFormState.physic)
        {

            Rigidbody BulletForce = Instantiate(PhysicBullets, ShootingDirect.transform.position, Quaternion.identity);
            

            BulletForce.velocity = ShootingDirect.forward * BulletForceSpeed;


        }
          else
        {
            Rigidbody BulletForce = Instantiate(SpiritBullet, ShootingDirect.transform.position, Quaternion.identity);


            BulletForce.velocity = ShootingDirect.forward * BulletForceSpeed;
        }
        StartItemCD();
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyFumoBehavioure : UseAbleItemSkill
{
    [SerializeField] float CastingArea = 15;
    [SerializeField] GameObject PhysicFumo;
    [SerializeField] GameObject SpiritFumo;

    GameObject FumoPreFab;
    GameObject PcFumo;

    GameObject Player;

    private void Start()
    {
        ResetItemUseingCount();
        if (ItemInPlayerForm == PlayerFormState.sprit)
        {
            Player =  SpiritWorld.Instance.SecondCharacter;
            FumoPreFab = SpiritFumo;
        }
        else
        {
            Player = SpiritWorld.Instance.player;
            FumoPreFab = PhysicFumo;
        }

    }

    public override void OnHoldingKey()
    {
        base.OnRelesaingKey();
     
            if (PcFumo == null)
                PcFumo = Instantiate(FumoPreFab, transform.position, Quaternion.identity);


            PcFumo.GetComponent<Fumo>().IsHolding(true);

            Camera mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
            {
                Vector3 target = hitInfo.point;
                target.y = transform.position.y;

                float distanceToPlayer = Vector3.Distance(Player.transform.position, target);

                if (distanceToPlayer <= CastingArea)
                {
                    PcFumo.transform.position = target;
                }
                else
                {
                    Vector3 direction = (target - Player.transform.position).normalized;
                    PcFumo.transform.position = Player.transform.position + direction * CastingArea;
                }
            
        }
    }


    public override void OnRelesaingKey()
    {
            base.OnRelesaingKey();
           ONCD = true;
            StartItemCD();
          PcFumo.GetComponent<Fumo>().IsHolding(false);
          
        

    }
}

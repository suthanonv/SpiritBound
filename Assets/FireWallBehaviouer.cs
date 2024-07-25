using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallBehaviouer : UseAbleItemSkill
{
    [SerializeField] GameObject PhysicLava;
    [SerializeField] GameObject SpiritLava;
    GameObject LavaPrefab;
    GameObject PlayerPosition;


    [SerializeField] float ActiveTime = 10;
    private void Start()
    {
        if (ItemInPlayerForm == PlayerFormState.sprit)
        {
            LavaPrefab = PhysicLava;
            PlayerPosition = SpiritWorld.Instance.SecondCharacter;

        }
        else
        {
            LavaPrefab = SpiritLava;
            PlayerPosition = SpiritWorld.Instance.player;

        }
    }
    public override void OnRelesaingKey()
    {
        base.OnRelesaingKey();
        GameObject Lava = Instantiate(LavaPrefab, PlayerPosition.transform);
        Lava.transform.position = PlayerPosition.transform.position;

        Destroy(Lava, ActiveTime);

        StartItemCD();
    }
}

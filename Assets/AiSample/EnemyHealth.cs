using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] Room RoomThatEnemyInSide;
    

    private void Start()
    {
        currenthealth = MaxHealth;
    }
    public override void Died()
    {
        RoomThatEnemyInSide.EnemyListInRoom.List.Remove(this.gameObject);
        Destroy(this.gameObject);
    }


}

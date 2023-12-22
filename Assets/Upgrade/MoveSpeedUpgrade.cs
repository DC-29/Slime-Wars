using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedUpgrade : UpgradeTypes
{
    public float speedIncrease = 0.1f;
    public override void OnActivated()
    {
        playerStats.moveSpeed += speedIncrease;
    }
}

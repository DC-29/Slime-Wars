using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : UpgradeTypes
{
    public float healthIncrease = 0.1f;
    public override void OnActivated()
    {
        playerStats.health += 10;
    }
}

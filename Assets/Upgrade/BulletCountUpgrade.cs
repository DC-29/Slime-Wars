using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCountUpgrade : UpgradeTypes
{
    public float bulletIncrease = 1;
    public override void OnActivated()
    {
        playerStats.maxBullets += bulletIncrease;
    }
}

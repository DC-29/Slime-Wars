using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUpgrade : UpgradeTypes
{
    public float reloadDecrease = 0.1f;
    public override void OnActivated()
    {
        playerStats.reloadTime -= reloadDecrease;
    }
}

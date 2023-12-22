using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class UpgradeTypes : MonoBehaviour
{
    public PlayerStats playerStats;
    
    public abstract void OnActivated();
}



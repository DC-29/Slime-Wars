using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats playerStats;
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    public Shooting shooting;

    void Start()
    {
        playerStats.health = 100;
        playerStats.maxBullets = 5;
        playerStats.reloadTime =2;
        playerStats.moveSpeed = 3.5f;
    }

    private void Update() {
        
        playerMovement.moveSpeed = playerStats.moveSpeed;
        playerHealth.maxHealth = playerStats.health;
        shooting.maxBullets = playerStats.maxBullets;
        if (playerStats.reloadTime >0.1){
        shooting.reloadTime = playerStats.reloadTime;}
        else{shooting.reloadTime = 0.1f;}
        
    }

}

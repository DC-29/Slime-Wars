using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;

    
    int bulletDmg = 1;

    Upgrade upgradeSystem;
    public int xp;
    
    private void Start() {
        upgradeSystem = FindObjectOfType<Upgrade>();
    }

    private void Update() {
        if (enemyHealth <= 0 && gameObject.tag == "Enemy"){
            upgradeSystem.IncreaseXP(xp);
            Destroy(gameObject);
        }

        
    }
    
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "bullet"){
            
            enemyHealth -= bulletDmg;
        }

    

        
    } 


    private void OnCollisionStay2D(Collision2D other) {
        if (other.collider.tag == "shockwave"){
           
            enemyHealth -= 3;
        }
    }

    
     
    
}

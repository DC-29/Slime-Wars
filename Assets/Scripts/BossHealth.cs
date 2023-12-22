using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider slider;
    EnemyHealth enemyHealth;
    GameObject winScreen;
    Boss boss;
    PlayerHealth ph;

    void Start()
    {
        ph = FindObjectOfType<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        slider.maxValue = enemyHealth.enemyHealth;
        winScreen = ph.winScreen;
        boss = GetComponent<Boss>();
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemyHealth.enemyHealth;

        if(enemyHealth.enemyHealth <= 0){
            winScreen.SetActive(true);
            Destroy(boss.shadow);
            Destroy(gameObject);
            
            Time.timeScale = 0;
            
        }
    }
}

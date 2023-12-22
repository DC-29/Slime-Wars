using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnSys : MonoBehaviour
{
    
    [Serializable]
    public class Wave{
        public string name;
        public GameObject[] enemies;
        public int maxEnemyCount;
        public float time;
    }

    public Wave[] waves;
    public float radius = 7f;
    public Wave bossWave1;
    public Wave bossWave2;
    
    
    float timer = 0;
    public GameObject player;
    public GameObject boss;
    public float bossTime;
    bool bossSpawned;
    Boss bossScript;
    

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    
    private void Update() {
        
       
        timer += Time.deltaTime;
        for (int i = 0; i < waves.Length; i++){
            if (i == waves.Length -1){
                if ((int)timer >= (int)waves[i].time){
                    Spawn(waves[i]);
                }
            }
            else if ((int)timer >= (int)waves[i].time && (int)timer < (int)waves[i+1].time){
                Spawn(waves[i]);
                
            }
        }

    if (timer >= bossTime && GameObject.FindGameObjectsWithTag("Enemy").Length==0 && !bossSpawned){
            GameObject bossInstance = Instantiate(boss,RandomPointOnUnitRectangle(30,16),Quaternion.identity);
            bossScript = bossInstance.GetComponent<Boss>();
            bossSpawned=true;
           
            
        }


    if (bossSpawned){
    Debug.Log(bossScript.health == null);
    if (bossScript.health.enemyHealth<0.7*bossScript.maxHealth && bossScript.health.enemyHealth>0.5*bossScript.maxHealth){
        Spawn(bossWave1);
    }
    if (bossScript.health.enemyHealth<0.5*bossScript.maxHealth){
        Spawn(bossWave2);
    }

    }
    }


    void Spawn(Wave wave){
        
        while (GameObject.FindGameObjectsWithTag("Enemy").Length < wave.maxEnemyCount){
            
            Vector2 randomSpawn = RandomPointOnUnitRectangle(30,16); 
            if (wave.enemies.Length > 0){
            int randomEnemy = UnityEngine.Random.Range(0,wave.enemies.Length);
            
            Instantiate(wave.enemies[randomEnemy],randomSpawn,Quaternion.identity);}
        }
        
    }


    
    


    Vector2 RandomPointOnUnitRectangle(float width, float height)
    {

     float randomSide = UnityEngine.Random.Range(0,1f);
     float x;
     float y;
     if (randomSide <= 0.5){
        x = UnityEngine.Random.Range (-width/2,width/2) + player.transform.position.x;
        float randomNum = UnityEngine.Random.Range(0,1f);
        
        if (randomNum <= 0.5){
            y = height/2 + player.transform.position.y;
        }
        else {
            y = -height/2 + player.transform.position.y;
        }
     }
     else{
        y = UnityEngine.Random.Range (-height/2,height/2) + player.transform.position.y;
        float randomNum = UnityEngine.Random.Range(0,1f);
        
        if (randomNum <= 0.5){
            x = width/2 + player.transform.position.x;
        }
        else {
            x = -width/2 + player.transform.position.x;
        }
     }
     

     return new Vector2 (x, y);

    }
}

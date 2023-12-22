using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    
    public GameObject[] stuffs;
    public GameObject heart;

    private void Start() {
        Spawn();
        SpawnHeart();
    }

    void Spawn(){
        Vector2 randomSpawn = RandomPointInsideRectangle(transform);
        int randomStuff = UnityEngine.Random.Range(0,stuffs.Length);
        GameObject stuff = Instantiate(stuffs[randomStuff],randomSpawn,Quaternion.identity);
        stuff.transform.parent = transform;
    }

    void SpawnHeart(){
        Vector2 randomSpawn = RandomPointInsideRectangle(transform);
        int randomChance = UnityEngine.Random.Range(0,2);
        if (randomChance == 1){
            GameObject heartInstance = Instantiate(heart,randomSpawn,Quaternion.identity);
            heartInstance.transform.parent = transform;
        }
        
        
    }



    Vector2 RandomPointInsideRectangle(Transform current){
        return new Vector2(Random.Range(current.position.x-16,current.position.x + 16),
        Random.Range(current.position.y-8,current.position.y + 8));
    }
}

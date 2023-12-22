using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public ParticleSystem burstPrefab;
    

    void Start()
    {   
        if (gameObject != null){
            Destroy(gameObject,1.5f);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ParticleSystem burst = Instantiate(burstPrefab, transform.position, Quaternion.identity);
        burst.Play();
        
        Destroy(gameObject);
        
    }
}

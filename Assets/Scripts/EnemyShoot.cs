using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{   
    
   

    GameObject player;
    public Transform spawnPos;
    public float speed;
    public GameObject bullet;
    public float bulletForce;
    public float minDist = 10f;
    
    private void Start() {
        InvokeRepeating("Shoot",2,1);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        FlipSprite();
    }

    void FixedUpdate()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position,speed *Time.fixedDeltaTime);
        
    }

    void FlipSprite(){
        if (player.transform.position.x != transform.position.x){
            transform.localScale = new Vector2(-Mathf.Sign(player.transform.position.x - transform.position.x),1);
        }   
        
    }

   

    void Shoot(){
        float dist = Vector3.Magnitude(player.transform.position - transform.position);
        if (dist <= minDist){
        GameObject bulletInstance = Instantiate(bullet,spawnPos.position,Quaternion.identity);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        Vector2 dir = player.transform.position - transform.position;
        rb.AddForce(Vector3.Normalize(dir) * bulletForce, ForceMode2D.Impulse);
        }
    }

    



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    GameObject player;
    public float speed;

    private void Start() {
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
}

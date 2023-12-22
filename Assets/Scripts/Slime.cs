using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    GameObject player;
    float initMoveSpeed;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        initMoveSpeed = player.GetComponent<Player>().playerStats.moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            
            player.GetComponent<Player>().playerStats.moveSpeed = 2.8f;   
            InvokeRepeating("DoDamage",0,0.2f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            CancelInvoke("DoDamage");
            player.GetComponent<Player>().playerStats.moveSpeed = initMoveSpeed;  
            player.GetComponent<PlayerHealth>().playerSprite.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void DoDamage(){
        player.GetComponent<PlayerHealth>().health -= 2;
        player.GetComponent<PlayerHealth>().playerSprite.GetComponent<SpriteRenderer>().color = 
        player.GetComponent<PlayerHealth>().color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public GameObject playerSprite;
    public Color32 color;
    public bool invincible;
    public GameObject healthBar; 
    public int heartHealth = 20;
    public LoseScreen loseScreen;
    public AudioSource healthSound;
    [HideInInspector] public GameObject winScreen;
 
    private void Awake() {
        Time.timeScale = 1;
    }
    
    public void Start()
    {       
        
        health = maxHealth;
        healthBar.GetComponent<Slider>().minValue = 0; 
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        healthBar.GetComponent<Slider>().value = health; 
        loseScreen.gameObject.SetActive(false);
        
        winScreen = GameObject.FindGameObjectWithTag("winScreen");
        winScreen.SetActive(false);
    }
 
    public void Update() 
    {
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        healthBar.GetComponent<Slider>().value = health;
        if (health <= 0){
            Time.timeScale = 0;
            loseScreen.gameObject.SetActive(true);
        }
    }
    
   

    private void OnCollisionStay2D(Collision2D other) {
       
        if (other.collider.tag == "Enemy" && invincible == false){
            invincible = true;
            playerSprite.GetComponent<SpriteRenderer>().color = color;
            EnemyDamage enemy = other.gameObject.GetComponent<EnemyDamage>();
            health -= enemy.enemyDamage;
            Invoke("NotInvicible",0.2f);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "bullet" && invincible == false){
            
            
            EnemyDamage enemy = other.gameObject.GetComponent<EnemyDamage>();
            health -= enemy.enemyDamage;
            
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "heart"){
            if (health + heartHealth > maxHealth){
                health = maxHealth;
                healthSound.Play();
                Destroy(other.gameObject);
            }
            else{
                health += heartHealth;
                Destroy(other.gameObject);
            }
        }
    }

    void NotInvicible(){
        invincible = false;
        playerSprite.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

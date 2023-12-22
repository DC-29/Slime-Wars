using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{   
    public GameObject shockWave;
    PlayerHealth playerHealth;
    public float shockCost = 40;
    public float dashCost = 10f;
    public PlayerStats playerStats;
    bool canDash = true;
    public Color color;
    CameraShake cameraShake;
    public AudioSource explosion;
    public AudioSource dash;

    private void Start() {
        canDash = true;
        playerHealth =  GetComponent<PlayerHealth>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)){
            if (playerHealth.health>30){
                ShockWave();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            if (playerHealth.health > 10){
                StartCoroutine(Dash());
            }
            
        }
    }

    void ShockWave(){
        explosion.Play();
        GameObject shock = Instantiate(shockWave, transform.position, Quaternion.identity);
        float tempCamShake = cameraShake.shakeTime;
        cameraShake.shakeTime = 1f;
        cameraShake.ShakeCam();
        cameraShake.shakeTime = tempCamShake;
        playerHealth.health -= shockCost;
        Destroy(shock,0.4f);
        
    }

    IEnumerator Dash(){
        dash.Play();
        CapsuleCollider2D cap= GetComponent<CapsuleCollider2D>();
        cap.enabled = false;
        playerHealth.health -= dashCost;
        canDash = false;
        GetComponentInChildren<SpriteRenderer>().color = color;
        playerHealth.invincible = true;
        float oldMoveSpeed = playerStats.moveSpeed;
        playerStats.moveSpeed = 50;
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        playerStats.moveSpeed = oldMoveSpeed;
        playerHealth.invincible = false;
        cap.enabled =true;
        canDash = true;
    }
}

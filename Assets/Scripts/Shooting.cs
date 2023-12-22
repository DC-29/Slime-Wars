using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public AudioSource reload;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float rate = 1f;
    public float maxBullets = 5f;
    float bulletCount;
    bool reloading;
    public float reloadTime = 2f;
    public Image reloadImage;
    public TextMeshProUGUI bulletText;
    float cooldown;
    public AudioSource shootSound;
    public CameraShake camShake;

    public Animator anim;

    private void Start() {
        bulletCount = maxBullets;
        reloadImage.fillAmount = 0;
    }
    
    void Update()
    {   
        bulletText.text = bulletCount + "/" + maxBullets;
        
        if (Input.GetButtonDown("Fire1") && bulletCount > 0 && !reloading  && cooldown <= 0){
            camShake.ShakeCam();
            anim.SetTrigger("Shoot");
            cooldown = 0.4f;
            Shoot();
            
            
        }   
        
        if (Input.GetButtonDown("Fire1") && bulletCount == 0){
            bulletText.color = Color.red;
            Invoke("ChangeColor",0.2f);
        }

        if (Input.GetKeyDown(KeyCode.R)){
            reload.Play();
            reloading = true;
            Invoke("Reload",reloadTime);
        }

        if (reloading){
            reloadImage.fillAmount += Time.deltaTime/reloadTime;
        }
        else reloadImage.fillAmount = 0;

        if (cooldown >0){
            cooldown -= Time.deltaTime;
        }
    }

    private void Shoot(){
        shootSound.Play();
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);  
        bulletCount -=1;
                
    }

    void Reload(){
        bulletCount = maxBullets;
        reloading = false;
    }

    void ChangeColor(){
        bulletText.color = Color.black;
    }
}

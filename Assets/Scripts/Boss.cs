using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    public Transform[] spawnPoints;
    public GameObject ballPrefab;
    public float vel;
    Renderer m_Renderer;
    Rigidbody2D rb ;
    bool wasVisible;
    public GameObject shadowPrefab;
    [HideInInspector]  public GameObject shadow;
    bool stopStomping;
    public bool stomping;
    Animator anim;
    GameObject player;
    public float speed=1;
    bool shooting;
    [HideInInspector]public EnemyHealth health;
    float timer=2;
    [HideInInspector]public float maxHealth;
    public GameObject smokePrefab;
    bool shootStomp;
    public AudioSource stompSound;
    CameraShake camShake;
    public GameObject spawner;
    bool toofar;

    void Start()
    {
        shadow = Instantiate(shadowPrefab);
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        EventManager.stopStomp += StopStomp;
        m_Renderer = GetComponentInChildren<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<EnemyHealth>();
        maxHealth = health.enemyHealth;
        camShake = FindObjectOfType<CameraShake>();
        timer= 2;
          
    }

    private void Update() {
        
        
        timer -= Time.deltaTime;
        
        
        if (health.enemyHealth>0.7*maxHealth && timer <= 0){
            StartCoroutine(ShootBalls());
            
            timer = 1;
        }
        else if (health.enemyHealth>0.5*maxHealth && timer <= 0){
            Stomp();
            timer = 100;
        }
        else if (timer<=0){
            shootStomp = true;
            Stomp();
            timer = 100;
            
        }
        
        StompBasic();
        toofar = (transform.position - player.gameObject.transform.position).magnitude > 18;
        if(!stomping && !shooting && !toofar){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position,speed *Time.deltaTime);}
        if (!stomping && !shooting && toofar){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position,50 *Time.deltaTime);
        }
    }

    IEnumerator ShootBalls(){
        shooting = true;
        anim.SetTrigger("jump");
        yield return new WaitForSecondsRealtime(0.6f);
        camShake.ShakeCam();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject ball = Instantiate(ballPrefab, spawnPoints[i].position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().velocity = spawnPoints[i].right * vel;
            Destroy(ball,5);
        }
        spawner.transform.Rotate(new Vector3(0,0,15));
        shooting = false;

    }

    void Stomp(){
        
        rb.velocity  =Vector2.up * 30;
        stomping = true;


        

    }

    void StopStomp(){
        GetComponentInChildren<SpriteRenderer>().enabled = true;
        transform.position = (Vector2)shadow.transform.position + new Vector2(0,10);
        stopStomping = true;
        
    }


    void StompBasic(){
        if (stomping){
        
        if (!stopStomping){
        

        if (!m_Renderer.isVisible){
            rb.velocity =Vector2.zero;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            EventManager.StartStomp();
        }
        }


        if (stopStomping){
            if (transform.position.y > shadow.transform.position.y){
            rb.velocity = Vector2.down * 20;}
            else{
                rb.velocity = Vector2.zero;
                GameObject smoke = Instantiate(smokePrefab,transform.position,Quaternion.identity);
                Destroy(smoke,3);
                if (shootStomp){
                    ShootStomp();
                }
                stompSound.Play();
                camShake.ShakeCam();
                timer = 1;
                stopStomping = false;
                stomping = false;
                
                
            }
        }
        }
    }

    void ShootStomp(){
        
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject ball = Instantiate(ballPrefab, spawnPoints[i].position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().velocity = spawnPoints[i].right * vel;
            Destroy(ball,5);
        }
        
    }

    
}

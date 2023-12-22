using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShadow : MonoBehaviour
{
    public Vector2 offset;
    public GameObject boss;
    GameObject player;
    bool startStomping;
    [SerializeField] float speed=5;
    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("boss");
        EventManager.stomp += ShadowStomp;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (boss.GetComponent<Boss>().stomping){
        
        
        if (startStomping){
            anim.SetBool("stomp",true);
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
            if (transform.position == player.transform.position){
            StopStomp();
        }
        }
        if (!startStomping){
            anim.SetBool("stomp",false);
            
        }

        

        }
        else  transform.position = (Vector2)boss.transform.position + offset;


        
    }

    void ShadowStomp(){
        startStomping = true;
        
    }

    void StopStomp(){
        startStomping = false;
        EventManager.StopStomp();
    }

    private void OnDisable() {
        EventManager.stomp -= ShadowStomp;  
    }
}

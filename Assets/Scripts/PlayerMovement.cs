using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    public Vector2 movement;
    
    public float moveSpeed;
    public Vector2 trackVelocity;
    Vector2 lastPos;
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        lastPos = rb.position;
    }

    
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        FlipSprite();
        
    }

    private void FixedUpdate() {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        trackVelocity = (rb.position - lastPos) * 50;
        lastPos = rb.position;

        
    }


    void FlipSprite(){
        if (movement.x !=0){
            transform.localScale = new Vector2(Mathf.Sign(movement.x),1);
        }   
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGen : MonoBehaviour
{

    public GameObject mapChunk;
    Collider2D col;
    PlayerMovement pm;
    GameObject currentMapChunk;
    Vector2Int sizeChunk;
    public GameObject maps;
    


    private void Start() {
        pm = FindObjectOfType<PlayerMovement>();
        mapChunk.GetComponentInChildren<Tilemap>().CompressBounds();
        sizeChunk = (Vector2Int)mapChunk.GetComponentInChildren<Tilemap>().size * 4;
       
    }

    // Update is called once per frame
    void Update()
    {   
        if (pm.trackVelocity.x != 0 && pm.trackVelocity.y != 0){
        Vector2 targetPos = new Vector2(currentMapChunk.transform.position.x + sign(pm.trackVelocity.x)*sizeChunk.x,currentMapChunk.transform.position.y + sign(pm.trackVelocity.y)*sizeChunk.y);
        Vector2 targetPos2 = new Vector2(currentMapChunk.transform.position.x + sign(pm.trackVelocity.x)*sizeChunk.x,currentMapChunk.transform.position.y);
        Vector2 targetPos3 = new Vector2(currentMapChunk.transform.position.x ,currentMapChunk.transform.position.y + sign(pm.trackVelocity.y)*sizeChunk.y);
        Collider2D[] intersecting = Physics2D.OverlapCircleAll(targetPos,2f);
        Collider2D[] intersecting2 = Physics2D.OverlapCircleAll(targetPos2,2f);
        Collider2D[] intersecting3 = Physics2D.OverlapCircleAll(targetPos3,2f);

            if (intersecting.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
            if (intersecting2.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos2,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
            if (intersecting3.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos3,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
        }

        if (pm.trackVelocity.x == 0 && pm.trackVelocity.y != 0){
        Vector2 targetPos = new Vector2(currentMapChunk.transform.position.x ,currentMapChunk.transform.position.y + sign(pm.trackVelocity.y)*sizeChunk.y);
        Vector2 targetPos2 = new Vector2(currentMapChunk.transform.position.x + sizeChunk.x, currentMapChunk.transform.position.y + sign(pm.trackVelocity.y)*sizeChunk.y);
        Vector2 targetPos3 = new Vector2(currentMapChunk.transform.position.x - sizeChunk.x, currentMapChunk.transform.position.y + sign(pm.trackVelocity.y)*sizeChunk.y);
        
        
        Collider2D[] intersecting = Physics2D.OverlapCircleAll(targetPos,2f);
        Collider2D[] intersecting2 = Physics2D.OverlapCircleAll(targetPos2,2f);
        Collider2D[] intersecting3 = Physics2D.OverlapCircleAll(targetPos3,2f);
            if (intersecting.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
            if (intersecting2.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos2,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
            if (intersecting3.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos3,Quaternion.identity);
            map.transform.parent = maps.transform;
            }

        
        
        }


        if (pm.trackVelocity.y == 0 && pm.trackVelocity.x != 0){
        Vector2 targetPos = new Vector2(currentMapChunk.transform.position.x + sign(pm.trackVelocity.x)*sizeChunk.x,currentMapChunk.transform.position.y);
        Vector2 targetPos2 = new Vector2(currentMapChunk.transform.position.x + sign(pm.trackVelocity.x)*sizeChunk.x,currentMapChunk.transform.position.y +sizeChunk.y);
        Vector2 targetPos3 = new Vector2(currentMapChunk.transform.position.x + sign(pm.trackVelocity.x)*sizeChunk.x,currentMapChunk.transform.position.y - sizeChunk.y);
        Collider2D[] intersecting = Physics2D.OverlapCircleAll(targetPos,2f);
        Collider2D[] intersecting2 = Physics2D.OverlapCircleAll(targetPos2,2f);
        Collider2D[] intersecting3 = Physics2D.OverlapCircleAll(targetPos3,2f);
            if (intersecting.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
            if (intersecting2.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos2,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
            if (intersecting3.Length==0){
            GameObject map = Instantiate(mapChunk,targetPos3,Quaternion.identity);
            map.transform.parent = maps.transform;
            }
        }




        foreach (Transform map in maps.transform)
        {
            if (Vector3.Magnitude(transform.position - map.position) > 50){
                Destroy(map.gameObject);
            }
        }   
    
    }

    

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "BG"){
        currentMapChunk = other.gameObject;
        }
    }

    int sign(float x){
        if (x == 0){
            return 0;
        }
        else return (int)Mathf.Sign(x);
    }


    

    
}

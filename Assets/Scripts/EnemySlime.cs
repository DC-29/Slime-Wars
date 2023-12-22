using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public GameObject slime;

    private void Start() {
        InvokeRepeating("DropSlime",2,1.5f);
    }


    void DropSlime(){
        GameObject instSlime = Instantiate(slime,transform.position,Quaternion.identity);
        Destroy(instSlime,4);    
    }
}

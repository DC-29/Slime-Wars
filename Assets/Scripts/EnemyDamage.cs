using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int enemyDamage;
    Player player;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        if ((transform.position - player.gameObject.transform.position).magnitude > 16 && gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
    }
}

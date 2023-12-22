using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Rigidbody2D rbGun;
    Vector2 mousePos;
    [SerializeField] Camera cam;
    [SerializeField] GameObject player;

    void Start()
    {
        rbGun = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate() {
        rbGun.position  = player.transform.position;
        Vector2 lookDir = mousePos - rbGun.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        rbGun.rotation = angle;
    }
}

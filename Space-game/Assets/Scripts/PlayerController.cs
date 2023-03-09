using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float angle;
    private float dt;

    private Camera mainCamera;
    private Rigidbody2D rb;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveSpeed;

    [SerializeField] private GunScript gun;

    [SerializeField] private float fireRate;
    private bool fire;
    private float currentTime = 1;


    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        dt = Time.fixedDeltaTime;
        rb.AddForceAtPosition(new Vector2(0, 1), new Vector2(0, 21));
        gun = GetComponentInChildren<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        var pos = transform.position;
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var dir = mousePos - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        moveDir = Vector2.zero;

        if (Input.GetKey("w")) moveDir.y = 1;
        else if (Input.GetKey("s")) moveDir.y = -1;

        if (Input.GetKey("d")) moveDir.x = 1;
        else if (Input.GetKey("a")) moveDir.x = -1;

        if (Input.GetMouseButtonDown(0)) fire = true;
        else if (Input.GetMouseButtonUp(0)) fire = false;

        if (fire && currentTime > 1 / fireRate)
        {
            currentTime = 0;
            gun.Shoot();
        }

        moveDir.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
    private void FixedUpdate()
    {
        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * dt);
        rb.velocity = Vector2.Lerp(rb.velocity, moveDir * moveSpeed, moveAcceleration * dt);
    }
}

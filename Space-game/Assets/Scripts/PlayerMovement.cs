using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float angle;
    private float dt;

    private Camera mainCamera;
    private Rigidbody2D rb;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveSpeed;

    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        dt = Time.fixedDeltaTime;
        rb.AddForceAtPosition(new Vector2(0, 1), new Vector2(0, 21));
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var dir = mousePos - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        moveDir = Vector2.zero;

        if (Input.GetKey("w")) moveDir.y = 1;
        else if (Input.GetKey("s")) moveDir.y = -1;

        if (Input.GetKey("d")) moveDir.x = 1;
        else if (Input.GetKey("a")) moveDir.x = -1;

        moveDir.Normalize();
    }
    private void FixedUpdate()
    {
        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * dt);
        rb.velocity = Vector2.Lerp(rb.velocity, moveDir * moveSpeed, moveAcceleration * dt);
    }
}

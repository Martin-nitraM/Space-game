using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float dt;

    private Rigidbody2D rb;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dt = Time.fixedDeltaTime;
        target = GameObject.Find("Player").transform.GetChild(0);
    }

    void FixedUpdate()
    {
        var pos = transform.position;
        var targetPos = target.position;
        var dir = targetPos - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * dt);
        var moveDir = this.transform.right;
        rb.velocity = Vector2.Lerp(rb.velocity, moveDir * moveSpeed, moveAcceleration * dt);
    }
}

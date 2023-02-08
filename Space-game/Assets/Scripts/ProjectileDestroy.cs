using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform source;
    public float maxDistance;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * 7;
        maxDistance *= maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = source.position - transform.position;
        if (distance.sqrMagnitude > maxDistance)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] float fireRate = 1.0f;
    bool spawn;

    float t = 1;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime; 
        if (Input.GetMouseButtonDown(0))
        {
            spawn = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            spawn= false;
        }

        if (spawn && t > 1 / fireRate)
        {
            Object p = Instantiate(projectile, projectileSpawn.position, transform.rotation);
            if (p is GameObject)
            {
                ProjectileDestroy projectileDestroy = p.GetComponent<ProjectileDestroy>();
                projectileDestroy.source = transform;
            }
            t = 0; 
        }
    }
}

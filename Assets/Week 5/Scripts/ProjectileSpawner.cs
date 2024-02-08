using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject axePrefab;
    float projectileSpawnTimer;
    public float projectileSpawnDelay = 5.0f;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimedProjectile();
    }

    public void TimedProjectile()
    {
        projectileSpawnTimer += Time.deltaTime;
        if (projectileSpawnTimer >= projectileSpawnDelay)
        {
            Instantiate(axePrefab);
            projectileSpawnTimer = 0;
        }
    }
    public void LaunchProjectile()
    {
        Instantiate(axePrefab);
    }
}

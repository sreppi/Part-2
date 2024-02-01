using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject planePrefab;
    public float planeSpawnTimer;
    public float planeSpawnDelay = 5.0f;
    public Transform spawn;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        planeSpawnTimer += Time.deltaTime;
        if (planeSpawnTimer >= planeSpawnDelay)
        {
            Instantiate(planePrefab, spawn.transform);
            planeSpawnTimer = 0;
        }
    }
}

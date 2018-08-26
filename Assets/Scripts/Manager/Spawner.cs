using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Assets.Assets;

public class Spawner : MonoBehaviour {
    public bool active = true;
    public Vector2 delayRange = new Vector2(1f, 1.5f);
    public GameObject[] enemiesPrefarb;
    private float nextSpawnTime = 0f;
    private float spawnTimer = 0f;

    private Vector3 topLeftSpawner()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight + 2, 0));
    }
    private Vector3 topRightSpawner()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight + 2, 0));
    }
    private Vector3 generateSpawnerPos()
    {
        return new Vector3(UnityEngine.Random.Range(topLeftSpawner().x,
            topRightSpawner().x), 
            topLeftSpawner().y, 0);
    }
    private float delay
    {
        get
        {
            return UnityEngine.Random.Range(delayRange.x, delayRange.y);
        }
    }
   
    void Update()
    {
        GenerateEnemy();
    }
    void GenerateEnemy()
    {
        if (spawnTimer >= nextSpawnTime)
        {
            Vector3 randomPosition = generateSpawnerPos();
            GameObject enemy = enemiesPrefarb[Random.Range(0, enemiesPrefarb.Length)];
            
            GameObject spawnEnemy = (GameObject)Instantiate(enemy, randomPosition, Quaternion.identity);
            nextSpawnTime = spawnTimer + delay;
        }
        spawnTimer += Time.deltaTime;
    }
  
}

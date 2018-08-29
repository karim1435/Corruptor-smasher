using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Assets.Assets;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private Vector2 delayRange = new Vector2(1f, 1.5f);
    [SerializeField]
    private GameObject[] enemiesPrefarb;

    private float nextSpawnTime = 0f;
    private float spawnTimer = 0f;

    private Vector3 topLeftSpawner
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(
                new Vector3(0, Camera.main.pixelHeight + 2, 0));
        }
    }
    private Vector3 topRightSpawner
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3
                (Camera.main.pixelWidth, Camera.main.pixelHeight + 2, 0));
        }
        
    }
    private Vector3 SpawnerPosition
    {
        get
        {
            return new Vector3(UnityEngine.Random.Range(topLeftSpawner.x,
            topRightSpawner.x),
            topLeftSpawner.y, 0);
        }  
    }
    private float DelayTime
    {
        get
        {
            return UnityEngine.Random.Range(delayRange.x, delayRange.y);
        }
    }

    void Update()
    {
        GenerateRandomEnemy();
    }
    void GenerateRandomEnemy()
    {
        if (spawnTimer >= nextSpawnTime)
        {
            GameObject enemy = enemiesPrefarb[Random.Range(0, enemiesPrefarb.Length)];
            
            GameObject spawnEnemy = (GameObject)Instantiate(enemy, SpawnerPosition, Quaternion.identity);
            nextSpawnTime = spawnTimer + DelayTime;
        }
        spawnTimer += Time.deltaTime;
    }
  
}

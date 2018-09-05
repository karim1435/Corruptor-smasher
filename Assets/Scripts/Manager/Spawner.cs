using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Assets.Assets;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private Vector2 delayEnemyRange = new Vector2(1f, 1.5f);
    [SerializeField]
    private Vector2 delayItemRange = new Vector2(1f, 1.5f);

    [SerializeField]
    private GameObject[] enemiesPrefarb;
    [SerializeField]
    private GameObject[] collectableItemPrefarb;
    private Vector3 TopLefftSpawner
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(
                new Vector3(75, Camera.main.pixelHeight + 2, 0));
        }
    }
    private Vector3 TopRightSpawner
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3
                (Camera.main.pixelWidth-75, Camera.main.pixelHeight + 2, 0));
        }
        
    }
    void Start()
    {
        GerarateGameObject();  
    }
    private Vector3 SpawnerPosition
    {
        get
        {
            return new Vector3(UnityEngine.Random.Range(TopLefftSpawner.x,
            TopRightSpawner.x),
            TopLefftSpawner.y, 0);
        }  
    }
    private float EnemyDelay
    {
        get
        {
            return UnityEngine.Random.Range(delayEnemyRange.x, delayEnemyRange.y);
        }
    }
    private float ItemDelay
    {
        get
        {
            return UnityEngine.Random.Range(delayItemRange.x, delayItemRange.y);
        }
    }
    private void GerarateGameObject()
    {
        StartCoroutine(Instantiate(collectableItemPrefarb, ItemDelay));
        StartCoroutine(Instantiate(enemiesPrefarb, EnemyDelay));
    }
    private IEnumerator Instantiate(GameObject[] prefarb,float delay)
    {
        if (GameManager.Instance.IsGameRunning())
        {
            GameObject objectToSpawn = prefarb[Random.Range(0, prefarb.Length)];
            GameObject spawnGameObjecrt = (GameObject)Instantiate(objectToSpawn, SpawnerPosition, Quaternion.identity);
        }
        yield return new WaitForSeconds(delay);
        StartCoroutine(Instantiate(prefarb, delay));
    }
}

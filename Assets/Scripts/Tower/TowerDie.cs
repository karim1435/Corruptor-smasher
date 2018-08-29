using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Attacker;
using Assets.Scripts.Manager;

public class TowerDie : MonoBehaviour {

    private TowerHealth towerHealth;
    private bool isGameOver = false;
    private GoodEnemy goodEnemy;
 
    void Start()
    {
        towerHealth = GetComponent<TowerHealth>();
        towerHealth.OnZeroHp += Dead;
    }
    void OnDisable()
    {
        towerHealth.OnZeroHp -= Dead;
    }
    private void Dead()
    {
        isGameOver = true;
        GameManager.instance.GameState = GameState.GameOver;
    }
                                                   
}

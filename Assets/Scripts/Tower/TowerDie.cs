using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Attacker;
using Assets.Scripts.Manager;

public class TowerDie : MonoBehaviour {

    private TowerHealth towerHealth;
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
        GameManager.instance.GameState = GameState.GameOver;
    }
                                                   
}

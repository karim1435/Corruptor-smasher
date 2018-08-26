using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using Assets.Scripts.Attacker;

public class Electric : Defender
{
    private List<GameObject> enemies;
    private ElectricArea electricZone;

    public delegate void Fire();
    public event Fire OnFireAttack;
    void Start()
    {
        enemies = new List<GameObject>();
        electricZone = GameObject.FindObjectOfType<ElectricArea>();
        electricZone.OnElectricInArea += AddEnemy;
        electricZone.OnElectricOffArea += RemoveEnemy;
    }
    void Disable()
    {
        electricZone.OnElectricInArea -= AddEnemy;
        electricZone.OnElectricOffArea -= RemoveEnemy;
    }
    private void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }
    private void RemoveEnemy(GameObject other)
    {
        enemies.Remove(other);
    }
    protected override void KillAllIncomingEnemy()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
                enemy.GetComponent<BadEnemyDied>().Dead();
        }
        if(OnFireAttack!=null)
            OnFireAttack();
        ClearEnemies();
    }
    private void ClearEnemies()
    {
        enemies.Clear();
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using Assets.Scripts.Attacker;
using Assets.Scripts.Collectible_Item;

public class Electric : DefenderParent
{
    public delegate void Fire();
    public event Fire OnFireAttack;

    private List<GameObject> enemies;
    private ElectricArea electricZone;
    protected override void Start()
    {
        enemies = new List<GameObject>();

        electricZone = GameObject.FindObjectOfType<ElectricArea>();
        electricZone.OnElectricInArea += AddEnemy;
        electricZone.OnElectricOffArea += RemoveEnemy;

        base.Start();
    }
    void OnDisable()
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
        PlayClickEffects(gameAudio.thunderEffects);
        FireAnimaton();
        ClearEnemies();
    }

    private void FireAnimaton()
    {
        if (OnFireAttack != null)
            OnFireAttack();
    }
    private void ClearEnemies()
    {
        enemies.Clear();
    }
}
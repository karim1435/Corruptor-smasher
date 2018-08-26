using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using Assets.Scripts.Attacker;

public class Bomb : Defender
{
    protected override void KillAllIncomingEnemy()
    {
        foreach (var enemy in FindObjectsOfType<BadEnemyDied>())
        {
            if (enemy != null)
                enemy.Dead();
        }
    }
}


using Assets.Assets;
using Assets.Scripts.Attacker;
using Assets.Scripts.Collectible_Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Poison : Defender
{
    [SerializeField]
    private float poisonDelay=5f;

    protected override void KillAllIncomingEnemy()
    {
        foreach (var enemy in FindObjectsOfType<Movement>())
        {
            if (enemy != null && enemy.tag == Tag.Enemy)
                StartCoroutine(enemy.SilentMove(poisonDelay));
        }
    }
}

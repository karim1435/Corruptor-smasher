﻿using Assets.Scripts.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
namespace Assets.Scripts.Attacker
{
    public class GoodEnemyDie:EnemyDie
    {
        public override void Dead()
        {
            PlaySound();
            GameManager.Instance.GameState = GameState.GameOver;       
            base.Dead();
        }
        private void PlaySound()
        {
            SoundManager.Instance.PlayEffect(gameAudio.ohnoEffects);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Attacker
{
    public class BadEnemyDied:EnemyDie
    {
        [SerializeField]
        private int deadPoint;
        public override void Dead()
        {
            PlayDeathEffects();
            GameManager.Instance.AddScore(deadPoint);
            base.Dead();
        }

        private void PlayDeathEffects()
        {
            SoundManager.Instance.RandomSoundEffect(gameAudio.death);
        }
    }
}

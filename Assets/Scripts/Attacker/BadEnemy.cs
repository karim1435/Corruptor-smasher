using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Attacker
{
    public class BadEnemy:EnemyHealth
    {
        protected override void AttackHp(float attackPower)
        {
            CurrentHp -= attackPower;
            base.AttackHp(attackPower);
        }
    }
}

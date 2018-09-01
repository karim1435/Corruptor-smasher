using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Collectible_Item
{
    public class HearthItem : CollectibleItem
    {
        TowerHealth towerHealth;
        protected override void Start()
        {
            towerHealth = FindObjectOfType<TowerHealth>();
            base.Start();
        }
        protected override void GiveExtraBonus()
        {
            towerHealth.BonusHealth(bonus);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Collectible_Item
{
    public class HearthItem:CollectibleItem<TowerHealth>
    {
        protected override void GiveExtraBonus()
        {
            defender.gameObject.GetComponent<TowerHealth>().BonusHealth(bonus);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Collectible_Item
{
    class PoisonItem : CollectibleItem
    {
        Poison poison;
        protected override void Start()
        {
            poison = FindObjectOfType<Poison>();
            base.Start();
        }
        protected override void GiveExtraBonus()
        {
            poison.ExtraItem(bonus);
        }
    }
}

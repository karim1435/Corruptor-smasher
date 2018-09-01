using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Collectible_Item
{
    class BomItem : CollectibleItem
    {
        Bomb bomb;
        protected override void Start()
        {
            bomb = FindObjectOfType<Bomb>();
            base.Start();
        }
        protected override void GiveExtraBonus()
        {
            bomb.ExtraItem(bonus);
        }
    }
}

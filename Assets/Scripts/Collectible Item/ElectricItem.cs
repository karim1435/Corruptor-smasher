using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Collectible_Item
{
    class ElectricItem : CollectibleItem
    {
        Electric electric;
        protected override void Start()
        {
            electric = FindObjectOfType<Electric>();
            base.Start();
        }
        protected override void GiveExtraBonus()
        {
            electric.ExtraItem(bonus);
        }
    }
}

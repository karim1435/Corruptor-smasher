using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Collectible_Item
{
    class PoisonItem : CollectibleItem<Poison>
    {
        protected override void InfoBonus(string info)
        {
            info = "Extra poison +1";
            base.InfoBonus(info);
        }
    }
}

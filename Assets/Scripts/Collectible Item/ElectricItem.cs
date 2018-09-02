using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Collectible_Item
{
    class ElectricItem : CollectibleItem<Bomb>
    {
        protected override void InfoBonus(string info)
        {
            info = "Extra heart +1";
            base.InfoBonus(info);
        }
    }
}

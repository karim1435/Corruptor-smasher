using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Collectible_Item
{
    class BomItem : CollectibleItem<Bomb>
    {
        protected override void InfoBonus(string info)
        {
            info = "Extra bomb +1";
            base.InfoBonus(info);
        }
    }
}

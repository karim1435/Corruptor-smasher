using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Collectible_Item
{
    class ElectricItem : CollectibleItem<Electric>
    {
        protected override void InfoBonus(string info)
        {
            info = "Extra electric +1";
            base.InfoBonus(info);
            PlayAudio(audioGame.pickUpItem);
        }
    }
}

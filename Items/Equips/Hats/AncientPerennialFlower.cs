using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Face)]
    public class AncientPerennialFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Perennial Tulip");
            Tooltip.SetDefault("I'm a pretty girl!");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 7;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
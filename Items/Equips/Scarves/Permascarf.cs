using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Scarves
{
    [AutoloadEquip(EquipType.Neck)]
    public class Permascarf : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Permafrost's Scarf");
            Tooltip.SetDefault("Stay Frosty");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 4;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
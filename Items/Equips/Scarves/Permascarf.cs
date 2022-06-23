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
            Item.width = 24;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
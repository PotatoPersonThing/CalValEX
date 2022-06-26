using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class BigWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Large Perforator Mask");
            Tooltip.SetDefault("'In the anne-lead.'");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
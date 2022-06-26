using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class MidWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Medium Perforator Mask");
            Tooltip.SetDefault("'Worming its way to the top!'");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 1, 0, 0);
           
            Item.rare = 4;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class SmallWorm : ModItem
    {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 1, 0, 0);
           
            Item.rare = 4;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    internal class DraedonLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draedon Legs");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 14;
            item.rare = 1;
            item.vanity = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class ProfanedBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Profaned Balloon");
            Tooltip.SetDefault("'Patronage for Providence!'");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 44;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
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
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 44;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
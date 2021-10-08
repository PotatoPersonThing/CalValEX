using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class ProfanedBattery : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Crystal Core");
            Tooltip.SetDefault("Charged core of a profaned guardian: Could be used to make something powerful... but what?");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 33, 0);
            item.rare = 11;
        }
    }
}
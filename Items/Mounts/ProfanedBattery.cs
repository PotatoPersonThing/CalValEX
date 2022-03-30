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
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 33, 0);
            Item.rare = 11;
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class ProfanedWheels : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hot Wheels");
            Tooltip.SetDefault("Wheels made of pure profaned energy, They'd be good for doing donuts... \n but what could be fast enough to use them?");
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
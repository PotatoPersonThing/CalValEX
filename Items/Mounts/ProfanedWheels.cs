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
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 33, 0);
            item.rare = 11;
        }
    }
}
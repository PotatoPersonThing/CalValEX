using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class ProfanedFrame : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Some sort of ancient machine? It seems to be missing pieces...");
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
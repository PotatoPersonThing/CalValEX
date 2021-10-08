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
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 33, 0);
            item.rare = 11;
        }
    }
}
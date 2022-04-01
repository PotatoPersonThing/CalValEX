using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class MeldosaurusTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meldosaurus Trophy");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<MeldosaurusTrophyPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 9;
        }
    }
}
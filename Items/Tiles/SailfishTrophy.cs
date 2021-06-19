using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    internal class SailfishTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sailfish Trophy");
            Tooltip
                .SetDefault("'What if it were you \n" + "hanging up on this wall?'");
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
            item.createTile = ModContent.TileType<SailfishTrophyPlaced>();
            item.width = 38;
            item.height = 32;
            item.rare = 2;
        }
    }
}
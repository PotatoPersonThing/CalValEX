using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.Statues;

namespace CalValEX.Items.Tiles.Statues
{
    internal class ShrineoftheTides : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shrine of the Tides");
            Tooltip
                .SetDefault("My gift to the Water Goddess");
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
            item.createTile = ModContent.TileType<ShrineoftheTidesPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 7;
        }
    }
}
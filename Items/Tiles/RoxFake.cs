using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    internal class RoxFake : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Placeable Roxcalibur");
            Tooltip
                .SetDefault("'You can rock!'");
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
            item.createTile = ModContent.TileType<RoxFakePlaced>();
            item.width = 44;
            item.height = 64;
            item.rare = 4;
        }
    }
}
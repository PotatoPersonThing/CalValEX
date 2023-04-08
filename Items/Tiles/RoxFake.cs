using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class RoxFake : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Placeable Roxcalibur");
            /* Tooltip
                .SetDefault("'You can rock!'"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<RoxFakePlaced>();
            Item.width = 44;
            Item.height = 64;
            Item.rare = 4;
        }
    }
}
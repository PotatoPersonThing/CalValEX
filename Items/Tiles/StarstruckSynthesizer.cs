using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class StarstruckSynthesizer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starstruck Synthesizer");
            Tooltip
                .SetDefault("Used for special crafting");
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
            Item.createTile = ModContent.TileType<StarstruckSynthesizerPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 0;
        }
    }
}
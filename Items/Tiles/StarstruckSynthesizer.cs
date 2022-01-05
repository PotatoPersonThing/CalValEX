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
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<StarstruckSynthesizerPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }
    }
}
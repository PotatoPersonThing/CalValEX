using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    internal class PlagueDialysis : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Dialysis Machine");
            Tooltip
                .SetDefault("'We aren't allowed to inject you with the Plague. Sorry.'");
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
            item.createTile = ModContent.TileType<PlagueDialysisPlaced>();
            item.width = 32;
            item.height = 50;
            item.rare = ItemRarityID.LightRed;
        }
    }
}
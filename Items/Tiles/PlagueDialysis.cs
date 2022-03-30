using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class PlagueDialysis : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yharon Cloning Vat");
            Tooltip
                .SetDefault("'Sealed away for eternity'");
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
            Item.createTile = ModContent.TileType<PlagueDialysisPlaced>();
            Item.width = 32;
            Item.height = 50;
            Item.rare = ItemRarityID.Purple;
        }
    }
}
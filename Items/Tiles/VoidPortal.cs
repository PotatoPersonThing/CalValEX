using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles
{
    public class VoidPortal : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Void Portal");
            /* Tooltip
                .SetDefault("The void calls out"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<VoidPortalPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalamityID.CalRarityID.Turquoise;
        }
    }
}
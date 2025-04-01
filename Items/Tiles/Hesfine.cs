using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria;

namespace CalValEX.Items.Tiles
{
    public class Hesfine : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orthocera Jacuzzi");
            /* Tooltip
                .SetDefault(":Grab:"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<HesfinePlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalamityID.CalRarityID.PureGreen;
        }
    }
}
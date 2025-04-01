using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Arsenal;
using Terraria.ID;

namespace CalValEX.Items.Tiles.FurnitureSets.Arsenal
{
    public class AgedRustGamingTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aged Lab Gaming Table");
            // Tooltip.SetDefault("G@m3 0n1");
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
            Item.createTile = ModContent.TileType<AgedRustGamingTablePlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalamityID.CalRarityID.DarkOrange;
        }
    }
}
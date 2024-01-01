using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Arsenal;
using Terraria.ID;

namespace CalValEX.Items.Tiles.FurnitureSets.Arsenal
{
    public class RustGamingTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lab Gaming Table");
            // Tooltip.SetDefault("Game On!");
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
            Item.createTile = ModContent.TileType<RustGamingTablePlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalamityID.CalRarityID.Darkorange;
        }
    }
}
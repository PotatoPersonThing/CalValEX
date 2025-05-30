﻿using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class DemonShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Demon Ram Shield");
            // Tooltip.SetDefault("It's too big to wear, no ramming sorry");
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
            Item.createTile = ModContent.TileType<DemonShieldPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalamityID.CalRarityID.Violet;
        }
    }
}

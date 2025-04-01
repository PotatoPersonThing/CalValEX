﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.Paintings;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Paintings
{
    public class CalamityPaint : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("An Ancient Calamity");
            // Tooltip.SetDefault("'Blockaroz'");
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
            Item.createTile = ModContent.TileType<CalamityPaintPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalamityID.CalRarityID.Violet;
        }
    }
}
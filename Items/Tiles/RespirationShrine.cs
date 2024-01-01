using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class RespirationShrine : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Respiration Shrine");
            Item.ResearchUnlockCount = 1;
            /* Tooltip
                .SetDefault("Provides infinite breath in the Abyss within a certain radius, for your Abyss base needs.\n" + "Deactivating will near instantly cause you to start drowning\n" + "Basically cheating."); */
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
            Item.createTile = ModContent.TileType<RespirationShrinePlaced>();
            Item.width = 50;
            Item.height = 64;
            Item.rare = CalamityID.CalRarityID.HotPink;
        }
    }
}
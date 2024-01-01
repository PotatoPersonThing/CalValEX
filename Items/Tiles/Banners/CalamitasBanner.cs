using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Banners;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CalValEX.Items.Tiles.Banners
{
    public class CalamitasBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Acursed Banner");
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
            Item.createTile = ModContent.TileType<CalamitasBannerPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalamityID.CalRarityID.Darkorange;
        }
    }
}
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Plushies;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Tiles.Plushies
{
    public class CalamitasFumo : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Calamitas Plushie (Placeable)");
            // Tooltip.SetDefault("A dark artifact that must be handled with care\nMaster drop");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = CalamityID.CalRarityID.Violet;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.createTile = ModContent.TileType<CalaFumoPlaced>();
            Item.maxStack = 99;
        }
    }
}
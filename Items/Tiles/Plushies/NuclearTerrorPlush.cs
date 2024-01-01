using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Plushies;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CalValEX.Items.Tiles.Plushies {
    public class NuclearTerrorPlush : ModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Nuclear Terror Plushie (Placeable)");
            // Tooltip.SetDefault("Master drop");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults() {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = CalamityID.CalRarityID.PureGreen;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.createTile = ModContent.TileType<NuclearTerrorPlushPlaced>();
            Item.maxStack = 99;
        }
    }
}
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Plushies;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Tiles.Plushies {
    public class MirePlushP1 : ModItem {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/MirePlushP1";
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Shielded Cragmaw Mire Plushie (Placeable)");
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
            Item.createTile = ModContent.TileType<MirePlushPlacedP1>();
            Item.maxStack = 99;
        }
    }

    public class MirePlushP2 : ModItem {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/MirePlushP2";
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Slimy Cragmaw Mire Plushie (Placeable)");
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
            Item.createTile = ModContent.TileType<MirePlushPlacedP2>();
            Item.maxStack = 99;
        }
    }
}
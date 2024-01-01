using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Plushies;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CalValEX.Items.Plushies {
    public class NuclearTerrorPlushThrowable : ModItem {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/NuclearTerrorPlush";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

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
            Item.shoot = ModContent.ProjectileType<NuclearTerrorPlush>();
            Item.shootSpeed = 6f;
            Item.maxStack = 99;
        }
    }
}
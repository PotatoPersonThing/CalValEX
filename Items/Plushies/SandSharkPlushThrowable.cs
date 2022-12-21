using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Plushies;

namespace CalValEX.Items.Plushies {
    public class SandSharkPlushThrowable : ModItem {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/SandSharkPlush";
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 6;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<SandSharkPlush>();
            Item.shootSpeed = 6f;
            Item.maxStack = 99;
        }
    }
}
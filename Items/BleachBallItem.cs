using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles;

namespace CalValEX.Items {
    public class BleachBallItem : ModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Bleach Ball Beach Ball");
            // Tooltip.SetDefault("Careful, might pop");
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 10;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<BleachBallThrown>();
            Item.shootSpeed = 6f;
            Item.maxStack = 99;
        }
    }
}
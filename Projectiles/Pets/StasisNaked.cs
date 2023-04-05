using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets {
    public class StasisNaked : ModFlyingPet {
        public override float TeleportThreshold => 1440f;

        public override void SetStaticDefaults() {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Stasis Drone");
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults() {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void Animation(int state) => SimpleAnimation(speed: 8);

        public override void PetFunctionality(Player player) {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mNaked = false;

            if (modPlayer.mNaked)
                Projectile.timeLeft = 2;
        }

        public override void PostDraw(Color lightColor) {
            string glowmaskTexture = "CalValEX/Projectiles/Pets/StasisNaked_Glow";

            SimpleGlowmask(Main.spriteBatch, glowmaskTexture);
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class VoidOrb : ModFlyingPet
    {
        public override bool ShouldFlip => false;

        public override float TeleportThreshold => 1440f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Void Orb");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 50;
            projectile.height = 32;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            string glowmaskTexture = CalValEX.month == 12 ? "CalValEX/ExtraTextures/ChristmasPets/VoidOrbGlow" : "CalValEX/Projectiles/Pets/VoidOrb_Glow";
            SimpleGlowmask(spriteBatch, glowmaskTexture);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.VoidOrb = false;

            if (modPlayer.VoidOrb)
                projectile.timeLeft = 2;
        }
    }
}
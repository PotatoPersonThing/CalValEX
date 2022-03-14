using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod;
using System;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Graphics.Shaders;

namespace CalValEX.Projectiles.Pets
{
    public class StarJelly : ModProjectile
    {
        public PrimitiveTrail TrailDrawer = null;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Jelly");
            Main.projFrames[projectile.type] = 7;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BabySnowman);
            aiType = ProjectileID.BabySnowman;
            drawOriginOffsetY = -2;
            // projectile.width = 15;
            // projectile.height = 15;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            return true;
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 30) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 1; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 6;
            }
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.StarJelly = false;
            }
            if (modPlayer.StarJelly)
            {
                projectile.timeLeft = 2;
            }
        }

        private static Color ShaderColorOne = new Color(189, 255, 254);
        private static Color ShaderColorTwo = new Color(115, 234, 255);
        private static Color ShaderEndColor = new Color(33, 222, 255);

        private float PrimitiveWidthFunction(float completionRatio)
        {
            float arrowheadCutoff = 0.36f;
            float width = 45f;
            float minHeadWidth = 0.05f;
            float maxHeadWidth = width;
            if (completionRatio <= arrowheadCutoff)
                width = MathHelper.Lerp(minHeadWidth, maxHeadWidth, Utils.InverseLerp(0f, arrowheadCutoff, completionRatio, true));
            return width;
        }

        private Color PrimitiveColorFunction(float completionRatio)
        {
            float endFadeRatio = 0.41f;

            float completionRatioFactor = 2.7f;
            float globalTimeFactor = 5.3f;
            float endFadeFactor = 3.2f;
            float endFadeTerm = Utils.InverseLerp(0f, endFadeRatio * 0.5f, completionRatio, true) * endFadeFactor;
            float cosArgument = completionRatio * completionRatioFactor - Main.GlobalTime * globalTimeFactor + endFadeTerm;
            float startingInterpolant = (float)Math.Cos(cosArgument) * 0.5f + 0.5f;

            float colorLerpFactor = 0.6f;
            Color startingColor = Color.Lerp(ShaderColorOne, ShaderColorTwo, startingInterpolant * colorLerpFactor);

            return Color.Lerp(startingColor, ShaderEndColor, MathHelper.SmoothStep(0f, 1f, Utils.InverseLerp(0f, endFadeRatio, completionRatio, true)));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (TrailDrawer is null)
                TrailDrawer = new PrimitiveTrail(PrimitiveWidthFunction, PrimitiveColorFunction, specialShader: GameShaders.Misc["CalamityMod:TrailStreak"]);

            GameShaders.Misc["CalamityMod:TrailStreak"].SetShaderTexture(ModContent.GetTexture("CalamityMod/ExtraTextures/TelluricGlareStreak"));
            Vector2 overallOffset = projectile.Size * 0.5f - Main.screenPosition;
            overallOffset += projectile.velocity * 1.4f;
            TrailDrawer.Draw(projectile.oldPos, overallOffset, 92); // 58
            var thisRect = projectile.getRect();
            return true;
        }
    }
}
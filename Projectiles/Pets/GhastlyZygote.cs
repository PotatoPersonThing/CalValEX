using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using CalamityMod.DataStructures;

namespace CalValEX.Projectiles.Pets {
    public class GhastlyZygote : ModFlyingPet {
        public Player Owner => Main.player[Projectile.owner];
        public new bool ShouldFlip = false;
        public override void SetStaticDefaults() {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Ghastly Zygote");
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults() {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
        }

        public override float TeleportThreshold => 1440f;

        public override void Animation(int state) => SimpleAnimation(speed: 6);

        public override void PetFunctionality(Player player) {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.zygote = false;

            if (modPlayer.zygote)
                Projectile.timeLeft = 2;
        }

        public override void PostAI() => Lighting.AddLight(Projectile.Center, Color.AliceBlue.ToVector3());

        public override bool PreDrawExtras() {
            DrawCord();
            return true;
        }

        private void DrawCord() {
            Texture2D mainCordTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/GhastlyChain1").Value;
            Texture2D secCordTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/GhastlyChain2").Value;

            float mainCurv = MathHelper.Clamp(Math.Abs(Owner.Center.X - Projectile.Center.X) / 30f * 80, 15, 100);

            Vector2 controlPoint1 = Owner.Center - new Vector2(0, 0.5f) * mainCurv;
            Vector2 controlPoint2 = Projectile.Center + new Vector2(0, 1.2f) * mainCurv;

            BezierCurve curve = new BezierCurve(new Vector2[] { Owner.Center, controlPoint1, controlPoint2, Projectile.Center });
            int numPoints = 25; //"Should make dynamic based on curve length, but I'm not sure how to smoothly do that while using a bezier curve" -Graydee, from the code i referenced. I do agree.
            Vector2[] cordPositions = curve.GetPoints(numPoints).ToArray();

            for (int i = 1; i < numPoints; i++) {
                Vector2 position = cordPositions[i];
                float rotation = (cordPositions[i] - cordPositions[i - 1]).ToRotation() - MathHelper.PiOver2; //Calculate rotation based on direction from last point
                float yScale = Vector2.Distance(cordPositions[i], cordPositions[i - 1]) / mainCordTex.Height; //Calculate how much to squash/stretch for smooth chain based on distance between points
                Vector2 scale = new Vector2(1, yScale);
                Color chainLightColor = Lighting.GetColor((int)position.X / 16, (int)position.Y / 16); //Lighting of the position of the chain segment
                Vector2 origin = new Vector2(mainCordTex.Width / 2, mainCordTex.Height); //Draw from center bottom of texture
                Main.EntitySpriteDraw(mainCordTex, position - Main.screenPosition, null, chainLightColor, rotation, origin, scale, SpriteEffects.None, 0);
            }
        }

        public override void PostDraw(Color lightColor) {
            Texture2D tex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/GhastlyZygote").Value;
            Rectangle frame = tex.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (tex.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw(tex, Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame, Color.White, Projectile.rotation, new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY), Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
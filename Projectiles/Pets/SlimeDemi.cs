using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System.IO;
using System;

namespace CalValEX.Projectiles.Pets
{
    public class SlimeDemi : FlyingPet
    {
        double ballcounter = 0;
        double ballcounter2 = MathHelper.Pi;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Demi");
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.ignoreWater = true;
            facingLeft = false;
            spinRotation = false;
            shouldFlip = false;
            usesAura = false;
            usesGlowmask = false;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1840f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = 12f;
            inertia = 60f;
            animationSpeed = 30;
            spinRotationSpeedMult = 0.2f;
            offSetX = 56f * -Main.player[projectile.owner].direction;
            offSetY = -50f;
        }

        public override void SetUpAuraAndGlowmask() //for aura and glowmasks
        {
            auraTexture = "Projectiles/Pets/SlimeAura";
            auraRotates = true;
            auraRotation = true;
            auraRotationSpeedMult = 0.05f;

            glowmaskTexture = "";
            auraGlowmaskTexture = "";
        }

        public override void SetUpLight() //for when the pet emmits light
        {
            shouldLightUp = false;
            RGB = new Vector3(1, 1, 1);
            intensity = 1f;
            abyssLightLevel = 0;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mSlime = false;
            if (modPlayer.mSlime)
                projectile.timeLeft = 2;
            ballcounter+= 0.05f;
            ballcounter2 += 0.05f;
        }
        public override void SafePreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float textureRotation = MathHelper.Lerp((float)Math.PI / -4f, (float)Math.PI / 4f, 0.5f + MathHelper.Clamp(projectile.velocity.X / 50f, -0.5f, 0.5f));
            Texture2D texture = mod.GetTexture("Projectiles/Pets/SlimeDemi_Crimson");
            Texture2D texture2 = mod.GetTexture("Projectiles/Pets/SlimeDemi_Corruption");
            Vector2 Circle = projectile.Center + new Vector2(0, 50).RotatedBy(ballcounter);
            Vector2 draw = Circle - Main.screenPosition;
            spriteBatch.Draw(texture, draw, null, Color.White, textureRotation, new Vector2(texture.Width / 2f, texture.Height / 2), 1f, SpriteEffects.None, 0);
            Vector2 Circle2 = projectile.Center + new Vector2(0, 50).RotatedBy(ballcounter2);
            Vector2 draw2 = Circle2 - Main.screenPosition;
            spriteBatch.Draw(texture2, draw2, null, Color.White, textureRotation, new Vector2(texture2.Width / 2f, texture2.Height / 2), 1f, SpriteEffects.None, 0);
        }
        public override void SafeSendExtraAI(BinaryWriter writer)
        {
            writer.Write(ballcounter);
            writer.Write(ballcounter2);
        }

        public override void SafeReceiveExtraAI(BinaryReader reader)
        {
            ballcounter = reader.ReadDouble();
            ballcounter2 = reader.ReadDouble();
        }
    }
}
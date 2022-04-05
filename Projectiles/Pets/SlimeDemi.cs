using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System.IO;
using Terraria.ModLoader;
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
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.ignoreWater = true;
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
            offSetX = 56f * -Main.player[Projectile.owner].direction;
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
                Projectile.timeLeft = 2;
            ballcounter+= 0.05f;
            ballcounter2 += 0.05f;
        }
        public override void SafePreDraw(Color lightColor)
        {
            float textureRotation = MathHelper.Lerp((float)Math.PI / -4f, (float)Math.PI / 4f, 0.5f + MathHelper.Clamp(Projectile.velocity.X / 50f, -0.5f, 0.5f));
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SlimeDemi_Crimson").Value;
            Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SlimeDemi_Corruption").Value;
            Vector2 Circle = Projectile.Center + new Vector2(0, 50).RotatedBy(ballcounter);
            Vector2 draw = Circle - Main.screenPosition;
            Main.EntitySpriteDraw(texture, draw, null, Color.White, textureRotation, new Vector2(texture.Width / 2f, texture.Height / 2), 1f, SpriteEffects.None, 0);
            Vector2 Circle2 = Projectile.Center + new Vector2(0, 50).RotatedBy(ballcounter2);
            Vector2 draw2 = Circle2 - Main.screenPosition;
            Main.EntitySpriteDraw(texture2, draw2, null, Color.White, textureRotation, new Vector2(texture2.Width / 2f, texture2.Height / 2), 1f, SpriteEffects.None, 0);
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
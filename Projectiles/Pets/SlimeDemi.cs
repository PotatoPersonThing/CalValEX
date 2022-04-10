using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System.IO;
using System;

namespace CalValEX.Projectiles.Pets
{
    public class SlimeDemi : ModFlyingPet
    {
        double ballcounter = 0;
        double ballcounter2 = MathHelper.Pi;

        public override bool FacesLeft => false;

        public override bool ShouldFlip => false;

        public override float TeleportThreshold => 1840f;

        public override Vector2 FlyingOffset => new Vector2(56f * -Main.player[projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Slime Demi");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 24;
            projectile.height = 24;
            projectile.ignoreWater = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
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
            return true;
        }

        public override void Animation(int state)
        {
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            ballcounter += 0.05f;
            ballcounter2 += 0.05f;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mSlime = false;

            if (modPlayer.mSlime)
                projectile.timeLeft = 2;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(ballcounter);
            writer.Write(ballcounter2);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            ballcounter = reader.ReadDouble();
            ballcounter2 = reader.ReadDouble();
            base.ReceiveExtraAI(reader);
        }
    }
}
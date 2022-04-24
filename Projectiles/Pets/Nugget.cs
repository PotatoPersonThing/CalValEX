using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Projectiles.Pets
{
    public class Nugget : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("THE NUGGET");
            Main.projFrames[Projectile.type] = 10;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.PetLizard);
            AIType = ProjectileID.PetLizard;
            DrawOriginOffsetY = -5;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            return true;
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 80) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                Projectile.frame++;
                Projectile.frame %= 1; // Will reset to the first frame if you've gone through them all.
                Projectile.frameCounter = 9;
            }
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.Nugget = false;
            }
            if (modPlayer.Nugget)
            {
                Projectile.timeLeft = 2;
            }
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("Projectiles/Pets/Nugget_Glow").Value;
            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw
            (
                glowMask,
                Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame,
                Color.White,
                Projectile.rotation,
                new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY),
                Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0
            );
        }
    }
}
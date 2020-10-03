using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Projectiles.Pets.LightPets
    {

    public class ProGuard1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Potato1");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
            //drawOriginOffsetY = -100;
            projectile.light = 0.9f;
        }
        //  public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        // {
        //     Texture2D glowMask = mod.GetTexture("Items/Glowmasks/ProGuard2_Glowmask");
        //     Rectangle frame = glowMask.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
        //     frame.Height -= 1;
        //     float originOffsetX = (glowMask.Width - projectile.width) * 0.5f + projectile.width * 0.5f + drawOriginOffsetX;
        //     spriteBatch.Draw
        //     (
        //         glowMask,
        //         projectile.position - Main.screenPosition + new Vector2(originOffsetX + drawOffsetX, projectile.height / 2 + projectile.gfxOffY),
        //         frame,
        //         Color.White,
        //         projectile.rotation,
        //         new Vector2(originOffsetX, projectile.height / 2 - drawOriginOffsetY),
        //         projectile.scale,
        //         projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
        //         0f
        //     );
        // }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            return true;
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 9) // This will change the sprite every 8 frames (0.13 seconds). 
            {
                projectile.frame++;
                projectile.frame %= 1; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 1;
            }
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.ProGuard1 = false;
            }
            if (modPlayer.ProGuard1)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}
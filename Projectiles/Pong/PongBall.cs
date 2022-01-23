using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pong
{
    public class PongBall : ModProjectile
    {
        public bool checkpos = false;
        int hitcooldown = 0;
        int grace = 0;

        Vector2 nipah;
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongBall";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pong Ball");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            projectile.width = 23;
            projectile.height = 23;
            projectile.aiStyle = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 18000;
        }

        public override void AI()
        {
            grace--;

            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            if (projectile.position.X > player.Center.X + 392 || projectile.position.X < player.Center.X - 413)
            {
                projectile.velocity.X *= -1;
                grace = 90;
            }
            if (projectile.position.Y > player.Center.Y + 228 || projectile.position.Y < player.Center.Y - 253)
            {
                projectile.velocity.Y *= -1;
            }

            hitcooldown--;

            var thisRect = projectile.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (grace <= 0 && proj != null && proj.active && proj.getRect().Intersects(thisRect) && hitcooldown <= 0 && 
                    (proj.type == ModContent.ProjectileType<PlayerSlider>() ||
                    proj.type == ModContent.ProjectileType<DSSlider>() ||
                    proj.type == ModContent.ProjectileType<HiveSlider>() ||
                    proj.type == ModContent.ProjectileType<PerfSlider>() ||
                    proj.type == ModContent.ProjectileType<SGSlider>() ||
                    proj.type == ModContent.ProjectileType<CrabSlider>()
                    ))
                {
                    projectile.velocity.X *= -1;
                    //projectile.velocity.Y *= -1;
                    hitcooldown = 20;
                }
            }

            if (!modPlayer.pongactive)
            {
                projectile.active = false;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.pongactive)
            {
                Texture2D texture2 = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongBall");
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[projectile.type] * projectile.frame, texture2.Width, texture2.Height / Main.projFrames[projectile.type]);
                Vector2 position2 = projectile.Center - Main.screenPosition;
                position2.X += drawOffsetX;
                position2.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture2, position2, rectangle2, Color.White, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);
            }
        }
    }
}
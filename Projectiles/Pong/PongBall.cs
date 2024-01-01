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
            // DisplayName.SetDefault("Pong Ball");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 23;
            Projectile.height = 23;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
        }

        public override void AI()
        {
            grace--;

            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            if (Projectile.position.X > player.Center.X + 392 || Projectile.position.X < player.Center.X - 413)
            {
                Projectile.velocity.X *= -1;
                grace = 90;
            }
            if (Projectile.position.Y > player.Center.Y + 228 || Projectile.position.Y < player.Center.Y - 253)
            {
                Projectile.velocity.Y *= -1;
            }

            hitcooldown--;

            var thisRect = Projectile.getRect();

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
                    Projectile.velocity.X *= -1;
                    //Projectile.velocity.Y *= -1;
                    hitcooldown = 20;
                }
            }

            if (!modPlayer.pongactive)
            {
                Projectile.active = false;
            }
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.pongactive)
            {
                Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value;
                Rectangle rectangle2 = new(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                position2.X += DrawOffsetX;
                position2.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
            }
        }
    }
}
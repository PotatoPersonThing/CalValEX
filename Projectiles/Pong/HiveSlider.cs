using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pong
{
    public class HiveSlider : ModProjectile
    {
        public bool checkpos = false;

        Vector2 nipah;
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongSlider";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hive Mind Slider");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 25;
            Projectile.height = 78;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj.type == ModContent.ProjectileType<PlayerSlider>() && proj.velocity.Y != 0 && Projectile.position.Y > player.Center.Y - 254 && Projectile.position.Y < player.Center.Y + 169)
                {
                    Projectile.velocity.Y = proj.velocity.Y * 1.05f;
                }
            }

            if (Projectile.position.Y < player.Center.Y - 258)
            {
                Projectile.velocity.Y *= -1;
            }
            else if (Projectile.position.Y > player.Center.Y + 173)
            {
                Projectile.velocity.Y *= -1;
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
                Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongSlider").Value;
                Rectangle rectangle2 = new(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                position2.X += DrawOffsetX;
                position2.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
            }
        }
    }
}
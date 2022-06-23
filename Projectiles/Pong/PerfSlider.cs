using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pong
{
    public class PerfSlider : ModProjectile
    {
        public bool checkpos = false;
        int movementdev = -1;
        int movementdevtype = -1;
        int devcooldown = 0;

        Vector2 nipah;
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongSlider";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perforator Slider");
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

            devcooldown--;

            if (Main.rand.Next(120) == 0 && devcooldown <= 0)
            {
                movementdev = 120;
                if (Main.rand.Next(2) == 0)
                {
                    movementdevtype = 1;
                }
                else
                {
                    movementdevtype = -1;
                }
            }

            if (movementdev > 0)
            {
                movementdev--;
                if (movementdev == 24 || movementdev == 48 || movementdev == 72 || movementdev == 96 || movementdev == 120)
                {
                    movementdevtype *= -1;
                }
                if (movementdevtype == -1)
                {
                    Projectile.velocity.Y = -15;
                }
                else
                {
                    Projectile.velocity.Y = 15;
                }
                devcooldown = 120;
            }

            if (movementdev == 0)
            {
                Projectile.velocity.Y = 5;
            }

            if (Projectile.position.Y < player.Center.Y - 258)
            {
                movementdev = -1;
                Projectile.velocity.Y *= -1;
            }
            else if (Projectile.position.Y > player.Center.Y + 173)
            {
                movementdev = -1;
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
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                position2.X += DrawOffsetX;
                position2.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
            }
        }
    }
}
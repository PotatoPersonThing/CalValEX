using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pong
{
    public class CrabSlider : ModProjectile
    {
        public bool checkpos = false;
        int movementdev = -1;
        int movementdevtype = -1;
        int devcooldown = 0;

        Vector2 nipah;
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongSlider";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crabulon Slider");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.height = 78;
            projectile.aiStyle = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 18000;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            devcooldown--;

            if (Main.rand.Next(300) == 0 && devcooldown <= 0)
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
                    projectile.velocity.Y = -5;
                }
                else
                {
                    projectile.velocity.Y = 5;
                }
                devcooldown = 120;
            }

            if (movementdev == 0)
            {
                projectile.velocity.Y = 4;
            }

            if (projectile.position.Y < player.Center.Y - 258)
            {
                movementdev = -1;
                projectile.velocity.Y *= -1;
            }
            else if (projectile.position.Y > player.Center.Y + 173)
            {
                movementdev = -1;
                projectile.velocity.Y *= -1;
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
                Texture2D texture2 = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongSlider");
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[projectile.type] * projectile.frame, texture2.Width, texture2.Height / Main.projFrames[projectile.type]);
                Vector2 position2 = projectile.Center - Main.screenPosition;
                position2.X += drawOffsetX;
                position2.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture2, position2, rectangle2, Color.White, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);
            }
        }
    }
}
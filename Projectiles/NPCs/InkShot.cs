using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.NPCs
{
    public class InkShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ink Shot");
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 12;
            projectile.scale = 2f;
            projectile.damage = 20;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.penetrate = 2;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, projectile.GetAlpha(lightColor), projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            int killdust = 0;
            while (killdust < 9)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 97, -projectile.velocity.X * 0.05f, -projectile.velocity.Y * 0.05f, 50, default, 1f);
                killdust += 1;
            }
        }
    }
}
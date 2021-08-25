using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.NPCs
{
    public class OracleNPC_Cards : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oracle Card");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.damage = 20;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int randNumb = Main.rand.Next(0, 6); //change this to higher or lower, depending on how many debuffs it can potentially inflict
            switch (randNumb)
            {
                case 0:
                    target.AddBuff(BuffID.OnFire, Main.rand.Next(300, 1200)); //5 to 25 seconds (each second is 60 ticks)
                    break;

                case 1:
                    target.AddBuff(BuffID.Poisoned, Main.rand.Next(300, 1200));
                    break;

                case 2:
                    target.AddBuff(BuffID.Confused, Main.rand.Next(300, 1200));
                    break;

                case 3:
                    target.AddBuff(BuffID.BrokenArmor, Main.rand.Next(300, 1200));
                    break;

                case 4:
                    target.AddBuff(BuffID.CursedInferno, Main.rand.Next(300, 1200));
                    break;

                default:
                    target.AddBuff(BuffID.Ichor, Main.rand.Next(300, 1200));
                    break;
            }
        }

        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] > 60)
            {
                projectile.velocity.Y += 0.1f;
            }
            projectile.rotation += 0.6f;
            if (projectile.rotation > MathHelper.TwoPi)
            {
                projectile.rotation -= MathHelper.TwoPi;
            }
            else if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.TwoPi;
            }
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
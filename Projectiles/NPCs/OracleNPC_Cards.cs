using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.NPCs
{
    public class OracleNPC_Cards : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Oracle Card");
        }

        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.damage = 20;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.penetrate = 3;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 60)
            {
                Projectile.velocity.Y += 0.1f;
            }
            Projectile.rotation += 0.6f;
            if (Projectile.rotation > MathHelper.TwoPi)
            {
                Projectile.rotation -= MathHelper.TwoPi;
            }
            else if (Projectile.rotation < 0)
            {
                Projectile.rotation += MathHelper.TwoPi;
            }
        }

        public override void OnKill(int timeLeft)
        {
            int killdust = 0;
            while (killdust < 9)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleMoss, -Projectile.velocity.X * 0.05f, -Projectile.velocity.Y * 0.05f, 50, default, 1f);
                killdust += 1;
            }
        }
    }
}
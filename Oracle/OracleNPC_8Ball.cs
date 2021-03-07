using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Oracle
{
    public class OracleNPC_8Ball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oracle's Magic 8 Ball");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.damage = 10;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.knockBack = 2f;
            projectile.aiStyle = 14;
            projectile.timeLeft = 300;
        }

        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] > 60)
            {
                projectile.velocity.Y += 0.1f;
            }
        }

        public override void Kill(int timeLeft)
        {
            int killdust = 0;
            while (killdust < 9)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 33, -projectile.velocity.X * 0.05f, -projectile.velocity.Y * 0.05f, 50, default, 1f);
                killdust += 1;
            }
        }
    }
}
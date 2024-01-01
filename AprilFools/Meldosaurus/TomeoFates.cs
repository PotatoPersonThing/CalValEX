using Terraria;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class TomeoFates : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Tome of Fates");
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.hostile = true;
            Projectile.timeLeft = 600;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Projectile.rotation += 0.4f;
            Projectile.ai[1]++;
            if (Projectile.ai[1] == 45)
            {
                Projectile.velocity *= -1;
            }
        }
    }
}
//using CalamityMod.Projectiles.Ranged;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class GodsFire : ModProjectile //(Does this count as code theft)
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("God's Fire");
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 100;
        }
    }
}
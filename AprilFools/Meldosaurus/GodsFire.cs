using CalamityMod.Projectiles.Ranged;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class GodsFire : CosmicFire //(Does this count as code theft)
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God's Fire");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.ranged = false;
            projectile.penetrate = -1;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 100;
        }
    }
}
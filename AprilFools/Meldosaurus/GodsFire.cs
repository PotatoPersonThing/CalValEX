using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    [ExtendsFromMod("CalamityMod")]
    public class GodsFire : CalamityMod.Projectiles.Ranged.CosmicFire //(Does this count as code theft)
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 100;
            Projectile.alpha = 255;
        }
    }
}
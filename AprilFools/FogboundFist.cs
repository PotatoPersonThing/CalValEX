using Terraria;
using Terraria.ModLoader;
using System;

namespace CalValEX.AprilFools
{
    public class FogboundFist : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 68;
            Projectile.height = 68;
            Projectile.hostile = true;
            Projectile.timeLeft = 240;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI;
            if (CalValEX.CalamityActive)
            {
                SpawnSmoke();
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public void SpawnSmoke()
        {
            Vector2 placementrun = new(Projectile.Center.X + Main.rand.Next(-5, 5), Projectile.Center.Y + Main.rand.Next(-6, 6));
            if (Main.rand.NextBool(8))
            {
                CalamityMod.Particles.Particle mist = new CalamityMod.Particles.MediumMistParticle(placementrun, Vector2.Zero, new Color(172, 238, 255), new Color(145, 170, 188), Main.rand.NextFloat(1.15f, 1.45f), 245 - Main.rand.Next(50), 0.02f);
                mist.Velocity = (mist.Position - Projectile.Center) * 0.2f + Projectile.velocity;
                CalamityMod.Particles.GeneralParticleHandler.SpawnParticle(mist);
            }
        }
    }
}
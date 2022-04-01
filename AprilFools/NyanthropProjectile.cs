using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools
{
	public class NyanthropProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 17f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 600f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 15f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}

        public override void AI()
        {
			if (Main.rand.Next(5) == 0) 
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.Next(-4,4), Main.rand.Next(-4, 4), ProjectileID.Typhoon, 20, 2f, projectile.owner);
            }
        }
    }
}
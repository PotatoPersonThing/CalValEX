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
			int speedboostx = 0;
			int speedboosty = 0;
			if (projectile.velocity.X < 5 && projectile.velocity.X > 0)
            {
				speedboostx += 4;
            }
			else if (projectile.velocity.X < 0 && projectile.velocity.X > -5)
			{
				speedboostx -= 4;
			}
			else 
            {
				speedboostx = (int)projectile.velocity.X;
            }
			if (projectile.velocity.Y < 5 && projectile.velocity.Y > 0)
			{
				speedboosty += 4;
			}
			else if (projectile.velocity.Y < 0 && projectile.velocity.Y > -5)
			{
				speedboosty -= 4;
			}
			else 
			{
				speedboosty = (int)projectile.velocity.Y;
			}
			if (Main.rand.Next(5) == 0) 
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, speedboostx, speedboosty, ProjectileID.Typhoon, 20, 2f, projectile.owner);
            }
			else
            {
				return;
            }
        }
    }
}
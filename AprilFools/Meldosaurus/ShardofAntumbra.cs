using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class ShardofAntumbra : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antumbral Shard");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.hostile = true;
            projectile.timeLeft = 480;
            projectile.aiStyle = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            projectile.ai[1]++;
            if (projectile.ai[1] == 30)
            {
                int killhim = (int)projectile.ai[0];
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 20);
                Vector2 position = projectile.Center;
                position.X = projectile.Center.X;
                Vector2 targetPosition = Main.player[killhim].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                projectile.velocity = direction * 18;
            }
            if (projectile.ai[1] < 30)
            {
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
                int killhim = (int)projectile.ai[0];
                projectile.rotation = projectile.AngleTo(Main.player[killhim].Center) + MathHelper.PiOver4;
            }
        }
    }
}
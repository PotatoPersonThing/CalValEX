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
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.hostile = true;
            Projectile.timeLeft = 480;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Projectile.ai[1]++;
            if (Projectile.ai[1] == 30)
            {
                int killhim = (int)Projectile.ai[0];
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item, (int)Projectile.Center.X, (int)Projectile.Center.Y, 20);
                Vector2 position = Projectile.Center;
                position.X = Projectile.Center.X;
                Vector2 targetPosition = Main.player[killhim].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                Projectile.velocity = direction * 18;
            }
            if (Projectile.ai[1] < 30)
            {
                Projectile.velocity.X = 0;
                Projectile.velocity.Y = 0;
                int killhim = (int)Projectile.ai[0];
                Projectile.rotation = Projectile.AngleTo(Main.player[killhim].Center) + MathHelper.PiOver4;
            }
        }
    }
}
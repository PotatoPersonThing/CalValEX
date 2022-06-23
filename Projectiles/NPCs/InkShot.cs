using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.NPCs
{
    public class InkShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ink Shot");
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 12;
            Projectile.scale = 2f;
            Projectile.damage = 20;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
        }

        public override void Kill(int timeLeft)
        {
            int killdust = 0;
            while (killdust < 9)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 97, -Projectile.velocity.X * 0.05f, -Projectile.velocity.Y * 0.05f, 50, default, 1f);
                killdust += 1;
            }
        }
    }
}
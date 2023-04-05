using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumPylon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wulfrum Pylon");
            Main.projFrames[Projectile.type] = 7;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
            DrawOriginOffsetY = -15;
            //drawOffsetX = -14;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                modPlayer.pylon = false;
            if (modPlayer.pylon)
                Projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center;
            vectorToOwner.X -= 8f;
            vectorToOwner.Y -= 56f;

            float value = 8f;

            float velY = MathHelper.Clamp(player.velocity.Y, -value, value);
            float velX = MathHelper.Clamp(player.velocity.X, -value, value);

            vectorToOwner.X += 0.5f * -velX;
            vectorToOwner.Y += 0.5f * -velY;

            Projectile.Center = vectorToOwner;

            if (Projectile.frameCounter++ % 8 == 7)
            {
                Projectile.frame++;
            }
            if (Projectile.frame >= 7)
            {
                Projectile.frame = 0;
            }

            Lighting.AddLight(Projectile.Center, new Vector3(0.2f, 0.35882353f, 0.58039216f));
        }
    }
}
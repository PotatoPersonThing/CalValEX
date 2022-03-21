using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumPylon : ModProjectile
    {
        public Player Owner => Main.player[projectile.owner];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Pylon");
            Main.projFrames[projectile.type] = 7;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
            drawOriginOffsetY = -15;
            //drawOffsetX = -14;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                modPlayer.pylon = false;
            if (modPlayer.pylon)
                projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center;
            vectorToOwner.Y -= 56f;

            float value = 8f;

            float velY = MathHelper.Clamp(player.velocity.Y, -value, value);
            float velX = MathHelper.Clamp(player.velocity.X, -value, value);

            vectorToOwner.X += 0.5f * -velX;
            vectorToOwner.Y += 0.5f * -velY;

            projectile.Center = vectorToOwner;

            if (projectile.frameCounter++ % 8 == 7)
            {
                projectile.frame++;
            }
            if (projectile.frame >= 7)
            {
                projectile.frame = 0;
            }

            Lighting.AddLight(projectile.Center, new Vector3(0.2f, 0.35882353f, 0.58039216f));
        }
    }
}
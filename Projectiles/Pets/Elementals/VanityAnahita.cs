using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityAnahita : ModProjectile
    {
        public override string Texture => "CalamityMod/NPCs/Leviathan/Siren";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Passive Anahita");
            Main.projFrames[projectile.type] = 6;
            Main.projPet[projectile.type] = true;
            drawOriginOffsetY = -15;
            //drawOffsetX = -14;
        }

        public override void SetDefaults()
        {
            projectile.width = 100;
            projectile.height = 190;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            projectile.alpha = 35;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                projectile.timeLeft = 0;
            if (!modPlayer.vanityhote)
                projectile.timeLeft = 0;
            if (modPlayer.vanityhote)
                projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center;
            vectorToOwner.Y -= 160f;
            vectorToOwner.X -= 40f;

            float value = 8f;

            float velY = MathHelper.Clamp(player.velocity.Y, -value, value);
            float velX = MathHelper.Clamp(player.velocity.X, -value, value);

            vectorToOwner.X += 0.5f * -velX;
            vectorToOwner.Y += 0.5f * -velY;

            projectile.Center = vectorToOwner;

            projectile.frameCounter++;
            if (projectile.frameCounter > 8)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 6)
            {
                projectile.frame = 0;
            }
        }
    }
}
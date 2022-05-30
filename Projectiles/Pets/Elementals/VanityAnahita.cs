using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityAnahita : ModProjectile
    {
        //public override string Texture => "CalamityMod/NPCs/Leviathan/Siren";
        public override string Texture => "CalamityMod/NPCs/Leviathan/Siren";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Passive Anahita");
            Main.projFrames[Projectile.type] = 6;
            Main.projPet[Projectile.type] = true;
            DrawOriginOffsetY = -15;
            //drawOffsetX = -14;
        }

        public override void SetDefaults()
        {
            Projectile.width = 100;
            Projectile.height = 190;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.alpha = 35;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                Projectile.timeLeft = 0;
            if (!modPlayer.vanityhote && !modPlayer.vanitysiren)
                Projectile.timeLeft = 0;
            if (modPlayer.vanityhote || modPlayer.vanitysiren)
                Projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center;
            vectorToOwner.Y -= 160f;
            vectorToOwner.X -= 40f;

            float value = 8f;

            float velY = MathHelper.Clamp(player.velocity.Y, -value, value);
            float velX = MathHelper.Clamp(player.velocity.X, -value, value);

            vectorToOwner.X += 0.5f * -velX;
            vectorToOwner.Y += 0.5f * -velY;

            Projectile.Center = vectorToOwner;

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 8)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 6)
            {
                Projectile.frame = 0;
            }
        }
    }
}
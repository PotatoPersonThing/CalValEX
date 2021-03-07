using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class Minimpious : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Minimpious");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 32;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            drawOriginOffsetY = -11;
            drawOffsetX = -21;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                modPlayer.mImp = false;
            if (modPlayer.mImp)
                projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (distanceToOwner > 2400f)
            {
                projectile.position = player.Center;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            if (projectile.velocity.X > 0f)
                projectile.spriteDirection = -1;
            else if (projectile.velocity.X < 0f)
                projectile.spriteDirection = 1;

            projectile.rotation = projectile.velocity.X * 0.1f;
            projectile.frameCounter++;
            if (projectile.frameCounter > 8)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame > 4)
                    projectile.frame = 0;
            }

            Lighting.AddLight(projectile.position, new Vector3(1.61568627f, 0.901960784f, 0.462745098f));

            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 55, 0, 0, 125);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.3f;
                Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(player.cLight, player);
            }

            float limit = 6.66f;

            Vector2 extraPos = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
            float posX = player.position.X + (player.width / 2) - extraPos.X;
            float posY = player.position.Y + (player.width / 2) - extraPos.Y;
            float num0 = 80;

            float num1 = (float)Math.Sqrt(posX * posX + posY * posY);

            if (num1 > 800f)
            {
                projectile.position.X = player.position.X + (player.height / 2) - (projectile.height / 2);
                projectile.position.Y = player.position.Y + (player.height / 2) - (projectile.height / 2);
            }
            else if (num1 > num0)
            {
                num1 = limit / num1;
                posX *= num1;
                posY *= num1;
                projectile.velocity.X = posX;
                projectile.velocity.Y = posY;
            }
            else
            {
                projectile.velocity *= 0.20f;
            }
        }
    }
}
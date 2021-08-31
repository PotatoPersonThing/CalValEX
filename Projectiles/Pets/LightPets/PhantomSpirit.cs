using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class PhantomSpirit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom Spirit");
            Main.projFrames[projectile.type] = 7;
            Main.projPet[projectile.type] = true;
            drawOriginOffsetY = -15;
            drawOffsetX = -14;
            ProjectileID.Sets.LightPet[projectile.type] = true;
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
                modPlayer.mPhan = false;
            if (modPlayer.mPhan)
                projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (distanceToOwner > 2000f)
            {
                projectile.position = player.Center;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            Lighting.AddLight(projectile.position, new Vector3(2.5f, 1.20588235f, 1.54901961f));
            float velocity = 2.5f;
            float limit = 5f;

            float extra = 240f;
            float extra2 = 60f;

            Vector2 extraPos = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
            float posX = player.position.X + (player.width / 2) - extraPos.X;
            float posY = player.position.Y + player.gfxOffY + (player.height / 2) - extraPos.Y;
            if (player.controlLeft)
                posX -= extra;
            else if (player.controlRight)
                posX += extra;

            if (player.controlDown)
                posY += extra;
            else
            {
                if (player.controlUp)
                    posY -= extra;
                posY -= extra2;
            }

            float num2 = (float)Math.Sqrt(posX * posX + posY * posY);

            if (num2 > 1000f)
            {
                projectile.position.X += posX;
                projectile.position.Y += posY;
            }

            if (projectile.localAI[0] == 1f)
            {
                if (num2 < 10f && Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) < limit && player.velocity.Y == 0f)
                    projectile.localAI[0] = 0f;

                limit = 12f;
                if (num2 < limit)
                {
                    projectile.velocity.X = posX;
                    projectile.velocity.Y = posY;
                }
                else
                {
                    num2 = limit / num2;
                    projectile.velocity.X = posX * num2;
                    projectile.velocity.Y = posY * num2;
                }

                if (Main.rand.NextFloat() < 0.75f)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, 0f, 0f, 164, new Color(255, 0, 251), 1f);
                    Main.dust[dust].scale = 0.75f;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(player.cLight, player);
                }

                if (projectile.velocity.X > 0.5f)
                    projectile.direction = -1;
                else if (projectile.velocity.X < -0.5f)
                    projectile.direction = 1;

                projectile.spriteDirection = projectile.direction;
                projectile.frame = 6;
                projectile.rotation -= (0.2f + Math.Abs(projectile.velocity.X) * 0.025f) * projectile.direction;

                return;
            }

            if (num2 > 350f)
                projectile.localAI[0] = 1f;

            if (projectile.velocity.X > 0.5f)
                projectile.direction = -1;
            else if (projectile.velocity.X < -0.5f)
                projectile.direction = 1;

            projectile.spriteDirection = projectile.direction;

            if (num2 < 10f)
            {
                projectile.velocity.X = posX;
                projectile.velocity.Y = posY;
                projectile.rotation = projectile.velocity.X * 0.05f;
                if (num2 < limit)
                {
                    projectile.position += projectile.velocity;
                    projectile.velocity *= 0f;
                    velocity = 0;
                }

                projectile.direction = -player.direction;
            }

            num2 = limit / num2;

            posX *= num2;
            posY *= num2;

            if (projectile.velocity.X < posX)
            {
                projectile.velocity.X += velocity;
                if (projectile.velocity.X < 0f)
                    projectile.velocity.X *= 0.99f;
            }

            if (projectile.velocity.X > posX)
            {
                projectile.velocity.X -= velocity;
                if (projectile.velocity.X > 0f)
                    projectile.velocity.X *= 0.99f;
            }

            if (projectile.velocity.Y < posY)
            {
                projectile.velocity.Y += velocity;
                if (projectile.velocity.Y < 0f)
                    projectile.velocity.Y *= 0.99f;
            }

            if (projectile.velocity.Y > posY)
            {
                projectile.velocity.Y -= velocity;
                if (projectile.velocity.Y > 0f)
                    projectile.velocity.Y *= 0.99f;
            }

            if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
                projectile.rotation = projectile.velocity.X * 0.05f;

            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;

                if (projectile.frame > 5)
                    projectile.frame = 0;
            }
        }
    }
}
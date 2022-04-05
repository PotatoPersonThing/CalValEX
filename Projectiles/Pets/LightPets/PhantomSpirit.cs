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
            Main.projFrames[Projectile.type] = 7;
            Main.projPet[Projectile.type] = true;
            DrawOriginOffsetY = -15;
            DrawOffsetX = -14;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
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
                modPlayer.mPhan = false;
            if (modPlayer.mPhan)
                Projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (distanceToOwner > 2000f)
            {
                Projectile.position = player.Center;
                Projectile.velocity *= 0.1f;
                Projectile.netUpdate = true;
            }

            Lighting.AddLight(Projectile.position, new Vector3(2.5f, 1.20588235f, 1.54901961f));
            float velocity = 2.5f;
            float limit = 5f;

            float extra = 240f;
            float extra2 = 60f;

            Vector2 extraPos = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
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
                Projectile.position.X += posX;
                Projectile.position.Y += posY;
            }

            if (Projectile.localAI[0] == 1f)
            {
                if (num2 < 10f && Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) < limit && player.velocity.Y == 0f)
                    Projectile.localAI[0] = 0f;

                limit = 12f;
                if (num2 < limit)
                {
                    Projectile.velocity.X = posX;
                    Projectile.velocity.Y = posY;
                }
                else
                {
                    num2 = limit / num2;
                    Projectile.velocity.X = posX * num2;
                    Projectile.velocity.Y = posY * num2;
                }

                if (Main.rand.NextFloat() < 0.75f)
                {
                    int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 66, 0f, 0f, 164, new Color(255, 0, 251), 1f);
                    Main.dust[dust].scale = 0.75f;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(player.cLight, player);
                }

                if (Projectile.velocity.X > 0.5f)
                    Projectile.direction = -1;
                else if (Projectile.velocity.X < -0.5f)
                    Projectile.direction = 1;

                Projectile.spriteDirection = Projectile.direction;
                Projectile.frame = 6;
                Projectile.rotation -= (0.2f + Math.Abs(Projectile.velocity.X) * 0.025f) * Projectile.direction;

                return;
            }

            if (num2 > 350f)
                Projectile.localAI[0] = 1f;

            if (Projectile.velocity.X > 0.5f)
                Projectile.direction = -1;
            else if (Projectile.velocity.X < -0.5f)
                Projectile.direction = 1;

            Projectile.spriteDirection = Projectile.direction;

            if (num2 < 10f)
            {
                Projectile.velocity.X = posX;
                Projectile.velocity.Y = posY;
                Projectile.rotation = Projectile.velocity.X * 0.05f;
                if (num2 < limit)
                {
                    Projectile.position += Projectile.velocity;
                    Projectile.velocity *= 0f;
                    velocity = 0;
                }

                Projectile.direction = -player.direction;
            }

            num2 = limit / num2;

            posX *= num2;
            posY *= num2;

            if (Projectile.velocity.X < posX)
            {
                Projectile.velocity.X += velocity;
                if (Projectile.velocity.X < 0f)
                    Projectile.velocity.X *= 0.99f;
            }

            if (Projectile.velocity.X > posX)
            {
                Projectile.velocity.X -= velocity;
                if (Projectile.velocity.X > 0f)
                    Projectile.velocity.X *= 0.99f;
            }

            if (Projectile.velocity.Y < posY)
            {
                Projectile.velocity.Y += velocity;
                if (Projectile.velocity.Y < 0f)
                    Projectile.velocity.Y *= 0.99f;
            }

            if (Projectile.velocity.Y > posY)
            {
                Projectile.velocity.Y -= velocity;
                if (Projectile.velocity.Y > 0f)
                    Projectile.velocity.Y *= 0.99f;
            }

            if (Projectile.velocity.X != 0f || Projectile.velocity.Y != 0f)
                Projectile.rotation = Projectile.velocity.X * 0.05f;

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 5)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;

                if (Projectile.frame > 5)
                    Projectile.frame = 0;
            }
        }
    }
}
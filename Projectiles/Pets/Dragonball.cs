using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CalValEX.Projectiles.Pets
{
    public class Dragonball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAL EXPLOSION");
            Main.projFrames[projectile.type] = 3;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]);
            writer.Write(projectile.tileCollide);
            writer.Write(ownerIsFar);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle(); //0 = jumping eternaly, 1 = flying
            projectile.tileCollide = reader.ReadBoolean();
            ownerIsFar = reader.ReadBoolean();
        }

        private bool ownerIsFar = false;
        public override void AI()
        {
            Player owner = Main.player[projectile.owner];

            CalValEXPlayer modOwner = owner.GetModPlayer<CalValEXPlayer>();

            if (!owner.active)
            {
                projectile.active = false;
                return;
            }

            if (owner.dead)
                modOwner.dBall = false;
            if (modOwner.dBall)
                projectile.timeLeft = 2;

            float offsetX = 48 * -owner.direction;
            Vector2 offset = new Vector2(offsetX, -50f);

            Vector2 vectorToOwner = owner.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (projectile.localAI[1] == 0)
            {
                if (!ownerIsFar)
                    projectile.velocity.Y += 0.1f;
                else
                    projectile.velocity.Y *= 0.92f;
                projectile.velocity.X *= 0.92f;
            }

            projectile.spriteDirection = projectile.velocity.X > 0 ? 1 : -1;

            if (distanceToOwner > 2400f)
            {
                projectile.position = owner.Center;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            switch ((int)projectile.localAI[1])
            {
                case 0: //JUMPE
                    projectile.tileCollide = true;
                    projectile.rotation = 0;
                    if (distanceToOwner > 320f)
                    {
                        projectile.ai[0]++;
                        if (projectile.ai[0] >= 5 && projectile.ai[0] < 90)
                        {
                            projectile.frame = 1;
                            ownerIsFar = true;
                        }
                        else if (projectile.ai[0] >= 90)
                        {
                            ResetMe();
                            projectile.localAI[1] = 1;
                        }
                    }
                    else if (projectile.ai[0] > 0)
                        projectile.ai[0]--;

                    int i = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                    int j = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;

                    if ((WorldGen.SolidTile(i, j + 1) || Main.tile[i, j + 1].type == TileID.Platforms) && !ownerIsFar)
                    {
                        projectile.velocity.Y = -4.5f;
                    }
                    break;
                case 1: //fly
                    projectile.tileCollide = false;
                    projectile.frame = 2;


                    if (distanceToOwner <= 240f && Collision.CanHit(projectile.position, projectile.width, projectile.height, owner.position, owner.width, owner.height))
                    {
                        projectile.frame = 0;
                        ownerIsFar = false;
                        ResetMe();
                        projectile.localAI[1] = 0;
                    }

                    vectorToOwner += offset;
                    distanceToOwner = vectorToOwner.Length();
                    //movement
                    if (distanceToOwner > 20f)
                    {
                        vectorToOwner.Normalize();
                        vectorToOwner *= 12;
                        projectile.velocity = (projectile.velocity * (45f - 1) + vectorToOwner) / 45f;
                    }
                    else if (projectile.velocity == Vector2.Zero)
                    {
                        //boop it so it moves
                        projectile.velocity.X = -0.15f;
                        projectile.velocity.Y = -0.15f;
                    }

                    if (Math.Abs(projectile.velocity.X) != 0)
                    {
                        float spinRotationSpeed = (projectile.velocity.X / 10) * 0.90f;
                        projectile.rotation += spinRotationSpeed;
                    }
                    break;
            }
        }

        private void ResetMe()
        {
            projectile.ai[0] = 0;
            projectile.ai[1] = 0;
            projectile.localAI[0] = 0;
            projectile.netUpdate = true;
        }
    }
}

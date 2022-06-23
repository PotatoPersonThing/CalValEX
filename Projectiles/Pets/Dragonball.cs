using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class Dragonball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALL EXPLOSION");
            Main.projFrames[Projectile.type] = 3;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 24;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(Projectile.localAI[0]);
            writer.Write(Projectile.localAI[1]);
            writer.Write(Projectile.tileCollide);
            writer.Write(ownerIsFar);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            Projectile.localAI[0] = reader.ReadSingle();
            Projectile.localAI[1] = reader.ReadSingle(); //0 = jumping eternaly, 1 = flying
            Projectile.tileCollide = reader.ReadBoolean();
            ownerIsFar = reader.ReadBoolean();
        }

        private bool ownerIsFar = false;

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            CalValEXPlayer modOwner = owner.GetModPlayer<CalValEXPlayer>();

            if (!owner.active)
            {
                Projectile.active = false;
                return;
            }

            if (owner.dead)
                modOwner.dBall = false;
            if (modOwner.dBall)
                Projectile.timeLeft = 2;
            CalValEX.Bumble = true;

            float offsetX = 48 * -owner.direction;
            Vector2 offset = new Vector2(offsetX, -50f);

            Vector2 vectorToOwner = owner.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (Projectile.localAI[1] == 0)
            {
                if (!ownerIsFar)
                    Projectile.velocity.Y += 0.1f;
                else
                    Projectile.velocity.Y *= 0.92f;
                Projectile.velocity.X *= 0.92f;
            }

            Projectile.spriteDirection = Projectile.velocity.X > 0 ? 1 : -1;

            if (distanceToOwner > 2400f)
            {
                Projectile.position = owner.Center;
                Projectile.velocity *= 0.1f;
                Projectile.netUpdate = true;
            }

            switch ((int)Projectile.localAI[1])
            {
                case 0: //JUMPE
                    Projectile.tileCollide = true;
                    Projectile.rotation = 0;
                    if (distanceToOwner > 320f)
                    {
                        Projectile.ai[0]++;
                        if (Projectile.ai[0] >= 5 && Projectile.ai[0] < 90)
                        {
                            Projectile.frame = 1;
                            ownerIsFar = true;
                        }
                        else if (Projectile.ai[0] >= 90)
                        {
                            ResetMe();
                            Projectile.localAI[1] = 1;
                        }
                    }
                    else if (Projectile.ai[0] > 0)
                        Projectile.ai[0]--;

                    int i = (int)(Projectile.position.X + (float)(Projectile.width / 2)) / 16;
                    int j = (int)(Projectile.position.Y + (float)(Projectile.height / 2)) / 16;

                    if ((WorldGen.SolidTile(i, j + 1) || Main.tile[i, j + 1].TileType == TileID.Platforms || Main.tile[i, j + 1].Slope > 0) && !ownerIsFar)
                    {
                        Projectile.velocity.Y = -4.5f;
                    }
                    break;

                case 1: //fly
                    Projectile.tileCollide = false;
                    Projectile.frame = 2;

                    if (distanceToOwner <= 240f && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, owner.position, owner.width, owner.height))
                    {
                        Projectile.frame = 0;
                        ownerIsFar = false;
                        ResetMe();
                        Projectile.localAI[1] = 0;
                    }

                    vectorToOwner += offset;
                    distanceToOwner = vectorToOwner.Length();
                    //movement
                    if (distanceToOwner > 20f)
                    {
                        vectorToOwner.Normalize();
                        vectorToOwner *= 12;
                        Projectile.velocity = (Projectile.velocity * (45f - 1) + vectorToOwner) / 45f;
                    }
                    else if (Projectile.velocity == Vector2.Zero)
                    {
                        //boop it so it moves
                        Projectile.velocity.X = -0.15f;
                        Projectile.velocity.Y = -0.15f;
                    }

                    if (Math.Abs(Projectile.velocity.X) != 0)
                    {
                        float spinRotationSpeed = (Projectile.velocity.X / 10) * 0.90f;
                        Projectile.rotation += spinRotationSpeed;
                    }
                    break;
            }
        }

        private void ResetMe()
        {
            Projectile.ai[0] = 0;
            Projectile.ai[1] = 0;
            Projectile.localAI[0] = 0;
            Projectile.netUpdate = true;
        }
    }
}
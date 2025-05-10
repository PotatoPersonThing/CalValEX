using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.NPCs.Oracle
{
    public class OracleNPCPet_Pet : ModProjectile
    {
        public override string Texture => "CalValEX/NPCs/Oracle/OracleNPCPet_Pet_Normal";

        public override void SetStaticDefaults() => Main.projFrames[Projectile.type] = 11;

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 34;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            DrawOriginOffsetY -= 8;
            DrawOffsetX = -6;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(Projectile.localAI[0]);
            writer.Write(Projectile.localAI[1]);
            writer.Write(Projectile.friendly);
            writer.Write(Projectile.tileCollide);
            writer.Write(State);
            writer.Write(isFlying);
            writer.Write(bloodLust);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            Projectile.localAI[0] = reader.ReadSingle();
            Projectile.localAI[1] = reader.ReadSingle();
            Projectile.friendly = reader.ReadBoolean();
            Projectile.tileCollide = reader.ReadBoolean();
            State = reader.ReadInt32();
            isFlying = reader.ReadBoolean();
            bloodLust = reader.ReadBoolean();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override bool PreAI()
        {
            if (OracleGlobalNPC.oracleNPC == -1)
            {
                Projectile.Kill();
                return false;
            }

            return true;
        }

        private int State = 0;
        private bool isFlying = false;
        private bool bloodLust = Main.bloodMoon;

        public override void AI()
        {
            NPC owner = Main.npc[OracleGlobalNPC.oracleNPC];
            /*
            if (Projectile.wet)
            {
                if (Projectile.velocity.Y >= 0.0f)
                {
                    Projectile.velocity.Y = -2f;
                }
            }
            */
            if (!owner.active)
            {
                Projectile.active = false;
                return;
            }

            if (State != -1 && State != 2)
            {
                Projectile.ignoreWater = false;
                Projectile.velocity.Y += 0.1f;
                Projectile.velocity.X *= 0.92f;
                Projectile.rotation = 0;
            }

            Vector2 targetCenter = owner.Center;
            Vector2 vectorToIdlePosition = targetCenter - Projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();

            if (State != -1)
            {
                if (vectorToIdlePosition.Length() > 1840f)
                {
                    Projectile.position = targetCenter;
                    Projectile.velocity *= 0.1f;
                    Projectile.netUpdate = true;
                }
            }
            else if (State == -1)
            {
                if (vectorToIdlePosition.Length() > 4800f)
                {
                    Projectile.position = targetCenter;
                    Projectile.velocity *= 0.1f;
                    Projectile.netUpdate = true;
                    if (OracleGlobalNPC.playerTargetTimer > 0)
                        OracleGlobalNPC.playerTargetTimer = -1;
                }
            }

            //Main.NewText("PLAYER TIMER: " + KawaggyGlobalNPC.playerTargetTimer);
            //Main.NewText("CURRENT STATE: " + State);

            float distanceFromTarget = 720;
            float distanceFromTargetAndOracle = 720;

            Projectile.spriteDirection = Projectile.velocity.X > 0 ? -1 : 1;

            bool foundTarget = false;

            if (!Main.bloodMoon)
            {
                Projectile.damage = 0;
                Projectile.netUpdate = true;
            }

            if (Main.bloodMoon)
            {
                Projectile.damage = 30;
                Projectile.netUpdate = true;
                State = -1;
            }
            switch (State)
            {
                case -1: //blood moon idle and attack
                    Projectile.tileCollide = false;
                    if (!Main.bloodMoon)
                    {
                        State = 0;
                        ResetMe();
                    }

                    if (Main.bloodMoon)
                    {
                        if (OracleGlobalNPC.playerTargetTimer > 0)
                        {
                            OracleGlobalNPC.playerTargetTimer--;
                            targetCenter = Main.player[OracleGlobalNPC.playerTarget].Center;
                            float newDistance = Vector2.Distance(Main.player[OracleGlobalNPC.playerTarget].Center, Projectile.Center);
                            distanceFromTarget = newDistance;
                            foundTarget = true;
                        }

                        if (!foundTarget)
                        {
                            for (int k = 0; k < Main.maxNPCs; k++)
                            {
                                NPC npc = Main.npc[k];
                                if (npc.CanBeChasedBy())
                                {
                                    float between = Vector2.Distance(npc.Center, Projectile.Center);
                                    bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                                    bool inRange = between < distanceFromTarget;
                                    if ((closest && inRange) || !foundTarget)
                                    {
                                        distanceFromTarget = between;
                                        distanceFromTargetAndOracle = Vector2.Distance(npc.Center, owner.Center);
                                        targetCenter = npc.Center;
                                        foundTarget = true;
                                    }
                                }
                            }
                        }
                    }

                    Projectile.ai[0]--;
                    Projectile.frameCounter++;

                    if (Projectile.ai[0] > 0)
                        Projectile.velocity *= 0.97f;
                    if (foundTarget && distanceFromTargetAndOracle > 720f)
                    {
                        if (distanceToIdlePosition > 25f)
                        {
                            vectorToIdlePosition.Y -= 48f;
                            vectorToIdlePosition.X += 16f * Projectile.direction;
                            vectorToIdlePosition.Normalize();
                            vectorToIdlePosition *= 8f;
                            Projectile.velocity = (Projectile.velocity * (20f - 1f) + vectorToIdlePosition) / 20f;
                        }
                    }
                    else if (foundTarget && distanceFromTarget > 120f && Projectile.ai[0] <= 0)
                    {
                        Vector2 direction = targetCenter - Projectile.Center;
                        direction.Normalize();
                        direction *= 8f;
                        Projectile.velocity = (Projectile.velocity * (20f - 1f) + direction) / 20f;
                    }
                    else if (foundTarget && distanceFromTarget < 120f && Projectile.ai[0] <= 0)
                    {
                        Projectile.ai[0] = 60;
                        Vector2 dashVelocity = Vector2.Normalize(targetCenter - Projectile.Center) * 10f;

                        Projectile.velocity = dashVelocity;
                        Projectile.netUpdate = true;
                    }

                    if (!foundTarget && distanceToIdlePosition > 25f)
                    {
                        if (distanceToIdlePosition > 25f)
                        {
                            vectorToIdlePosition.Y -= 48f;
                            vectorToIdlePosition.X += -16f * Projectile.direction;
                            vectorToIdlePosition.Normalize();
                            vectorToIdlePosition *= 2f;
                            Projectile.velocity = (Projectile.velocity * (20f - 1f) + vectorToIdlePosition) / 20f;
                        }
                    }

                    if (OracleGlobalNPC.playerTargetTimer > 0)
                    {
                        if (Main.player[OracleGlobalNPC.playerTarget].Hitbox.Intersects(Projectile.Hitbox))
                        {
                            Main.player[OracleGlobalNPC.playerTarget].Hurt(PlayerDeathReason.ByCustomReason(Main.player[OracleGlobalNPC.playerTarget].name + " tried to fight TUB."), Projectile.damage, -Main.player[OracleGlobalNPC.playerTarget].direction);
                        }
                    }

                    if (Projectile.ai[0] > 15)
                    {
                        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
                        Projectile.frame = 2;
                    }
                    if (Projectile.ai[0] <= 0)
                    {
                        Projectile.rotation = 0;
                        if (Projectile.frameCounter >= 15)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;
                            if (Projectile.frame < 7 || Projectile.frame > 10)
                                Projectile.frame = 7;
                        }
                    }
                    break;

                case 0: //idle
                    Projectile.tileCollide = true;
                    if (distanceToIdlePosition > 240f)
                    {
                        State = 1; //walk to owner
                        ResetMe();
                    }
                    Projectile.frame = 0;
                    break;

                case 1: //walking (jumping)
                    Projectile.tileCollide = true;
                    if (distanceToIdlePosition < 80f)
                    {
                        State = 0;
                        ResetMe();
                    }

                    if (distanceToIdlePosition > 340f)
                    {
                        State = 2;
                        ResetMe();
                    }

                    Projectile.frameCounter++;
                    Projectile.ai[0]--;

                    int i = (int)(Projectile.position.X + (float)(Projectile.width / 2)) / 16;
                    int j = (int)(Projectile.position.Y + (float)(Projectile.height)) / 16;

                    if (distanceToIdlePosition > 80f)
                    {
                        if (WorldGen.SolidTile(i, j + 1) || Main.tile[i, j + 1].TileType == TileID.Platforms)
                        {
                            Projectile.ai[0] = 60;
                            Projectile.velocity.Y = -3.5f;
                        }

                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= 8f;
                        Projectile.velocity.X = (Projectile.velocity.X * (20f - 1f) + vectorToIdlePosition.X) / 20f;
                    }

                    if (Projectile.ai[0] > 30)
                    {
                        if (Projectile.frameCounter >= 15)
                        {
                            if (Projectile.frame < 3)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;
                            }
                            else if (Projectile.frame > 3)
                            {
                                Projectile.frame = 0;
                            }
                        }
                    }
                    else if (Projectile.ai[0] > 15)
                    {
                        if (Projectile.frameCounter >= 10)
                        {
                            if (Projectile.frame == 3)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame = 4;
                            }
                            else if (Projectile.frame < 3)
                            {
                                Projectile.frame = 3;
                            }
                        }
                    }
                    else if (Projectile.ai[0] > 0)
                    {
                        if (Projectile.frameCounter >= 15)
                        {
                            if (Projectile.frame == 4)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame = 5;
                            }
                            else if (Projectile.frame == 5 && Projectile.frameCounter >= 25)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame = 6;
                            }
                            else if (Projectile.frame < 4)
                            {
                                Projectile.frame = 4;
                            }
                        }
                    }
                    break;

                case 2: //flying towards owner
                    Projectile.tileCollide = false;
                    if (distanceToIdlePosition < 240f)
                    {
                        State = 1;
                        ResetMe();
                    }

                    if (distanceToIdlePosition > 240f)
                    {
                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= 8f;
                        Projectile.velocity = (Projectile.velocity * (16f - 1) + vectorToIdlePosition) / 16f;
                    }

                    Projectile.rotation = 0;
                    if (Projectile.frameCounter >= 15)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame < 7 || Projectile.frame > 10)
                            Projectile.frame = 7;
                    }
                    break;
            }

            Projectile.friendly = foundTarget;
        }

        private void ResetMe()
        {
            Projectile.ai[0] = 0;
            Projectile.ai[1] = 0;
            Projectile.localAI[0] = 0;
            Projectile.localAI[1] = 0;
            Projectile.frameCounter = 0;
            Projectile.netUpdate = true;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            if (CalValEX.month == 10 || Main.halloween)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/NPCs/Oracle/OracleNPCPet_Pet_Halloween").Value;
                Rectangle rectangle = new(0, texture.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture.Width, texture.Height / Main.projFrames[Projectile.type]);
                Vector2 position = Projectile.Center - Main.screenPosition;
                position.X += DrawOffsetX;
                position.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture, position, rectangle, lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);
                return false;
            }
            return true;
        }
    }
}
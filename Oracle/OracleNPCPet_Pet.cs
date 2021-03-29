using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Oracle
{
    public class OracleNPCPet_Pet : ModProjectile
    {
        public override string Texture => "CalValEX/Oracle/OracleNPCPet_Pet_Normal";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TUB");
            Main.projFrames[projectile.type] = 11; //in code it's always one less
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 34;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            drawOriginOffsetY -= 8;
            drawOffsetX = -6;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]);
            writer.Write(projectile.friendly);
            writer.Write(projectile.tileCollide);
            writer.Write(State);
            writer.Write(isFlying);
            writer.Write(bloodLust);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();
            projectile.friendly = reader.ReadBoolean();
            projectile.tileCollide = reader.ReadBoolean();
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
                projectile.Kill();
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
            if (projectile.wet)
            {
                if (projectile.velocity.Y >= 0.0f)
                {
                    projectile.velocity.Y = -2f;
                }
            }
            */
            if (!owner.active)
            {
                projectile.active = false;
                return;
            }

            if (State != -1 && State != 2)
            {
                projectile.ignoreWater = false;
                projectile.velocity.Y += 0.1f;
                projectile.velocity.X *= 0.92f;
                projectile.rotation = 0;
            }

            Vector2 targetCenter = owner.Center;
            Vector2 vectorToIdlePosition = targetCenter - projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();

            if (State != -1)
            {
                if (vectorToIdlePosition.Length() > 1840f)
                {
                    projectile.position = targetCenter;
                    projectile.velocity *= 0.1f;
                    projectile.netUpdate = true;
                }
            }
            else if (State == -1)
            {
                if (vectorToIdlePosition.Length() > 4800f)
                {
                    projectile.position = targetCenter;
                    projectile.velocity *= 0.1f;
                    projectile.netUpdate = true;
                    if (OracleGlobalNPC.playerTargetTimer > 0)
                        OracleGlobalNPC.playerTargetTimer = -1;
                }
            }

            //Main.NewText("PLAYER TIMER: " + KawaggyGlobalNPC.playerTargetTimer);
            //Main.NewText("CURRENT STATE: " + State);

            float distanceFromTarget = 720;
            float distanceFromTargetAndOracle = 720;

            projectile.spriteDirection = projectile.velocity.X > 0 ? -1 : 1;

            bool foundTarget = false;

            if (!Main.bloodMoon)
            {
                projectile.damage = 0;
                projectile.netUpdate = true;
            }

            if (Main.bloodMoon)
            {
                projectile.damage = 30;
                projectile.netUpdate = true;
                State = -1;
            }
            switch (State)
            {
                case -1: //blood moon idle and attack
                    projectile.tileCollide = false;
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
                            float newDistance = Vector2.Distance(Main.player[OracleGlobalNPC.playerTarget].Center, projectile.Center);
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
                                    float between = Vector2.Distance(npc.Center, projectile.Center);
                                    bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
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

                    projectile.ai[0]--;
                    projectile.frameCounter++;

                    if (projectile.ai[0] > 0)
                        projectile.velocity *= 0.97f;
                    if (foundTarget && distanceFromTargetAndOracle > 720f)
                    {
                        if (distanceToIdlePosition > 25f)
                        {
                            vectorToIdlePosition.Y -= 48f;
                            vectorToIdlePosition.X += 16f * projectile.direction;
                            vectorToIdlePosition.Normalize();
                            vectorToIdlePosition *= 8f;
                            projectile.velocity = (projectile.velocity * (20f - 1f) + vectorToIdlePosition) / 20f;
                        }
                    }
                    else if (foundTarget && distanceFromTarget > 120f && projectile.ai[0] <= 0)
                    {
                        Vector2 direction = targetCenter - projectile.Center;
                        direction.Normalize();
                        direction *= 8f;
                        projectile.velocity = (projectile.velocity * (20f - 1f) + direction) / 20f;
                    }
                    else if (foundTarget && distanceFromTarget < 120f && projectile.ai[0] <= 0)
                    {
                        projectile.ai[0] = 60;
                        Vector2 dashVelocity = Vector2.Normalize(targetCenter - projectile.Center) * 10f;

                        projectile.velocity = dashVelocity;
                        projectile.netUpdate = true;
                    }

                    if (!foundTarget && distanceToIdlePosition > 25f)
                    {
                        if (distanceToIdlePosition > 25f)
                        {
                            vectorToIdlePosition.Y -= 48f;
                            vectorToIdlePosition.X += -16f * projectile.direction;
                            vectorToIdlePosition.Normalize();
                            vectorToIdlePosition *= 2f;
                            projectile.velocity = (projectile.velocity * (20f - 1f) + vectorToIdlePosition) / 20f;
                        }
                    }

                    if (OracleGlobalNPC.playerTargetTimer > 0)
                    {
                        if (Main.player[OracleGlobalNPC.playerTarget].Hitbox.Intersects(projectile.Hitbox))
                        {
                            Main.player[OracleGlobalNPC.playerTarget].Hurt(PlayerDeathReason.ByCustomReason(Main.player[OracleGlobalNPC.playerTarget].name + " tried to fight TUB."), projectile.damage, -Main.player[OracleGlobalNPC.playerTarget].direction);
                        }
                    }

                    if (projectile.ai[0] > 15)
                    {
                        projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
                        projectile.frame = 2;
                    }
                    if (projectile.ai[0] <= 0)
                    {
                        projectile.rotation = 0;
                        if (projectile.frameCounter >= 15)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame < 7 || projectile.frame > 10)
                                projectile.frame = 7;
                        }
                    }
                    break;

                case 0: //idle
                    projectile.tileCollide = true;
                    if (distanceToIdlePosition > 240f)
                    {
                        State = 1; //walk to owner
                        ResetMe();
                    }
                    projectile.frame = 0;
                    break;

                case 1: //walking (jumping)
                    projectile.tileCollide = true;
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

                    projectile.frameCounter++;
                    projectile.ai[0]--;

                    int i = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                    int j = (int)(projectile.position.Y + (float)(projectile.height)) / 16;

                    if (distanceToIdlePosition > 80f)
                    {
                        if (WorldGen.SolidTile(i, j + 1) || Main.tile[i, j + 1].type == TileID.Platforms)
                        {
                            projectile.ai[0] = 60;
                            projectile.velocity.Y = -3.5f;
                        }

                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= 8f;
                        projectile.velocity.X = (projectile.velocity.X * (20f - 1f) + vectorToIdlePosition.X) / 20f;
                    }

                    if (projectile.ai[0] > 30)
                    {
                        if (projectile.frameCounter >= 15)
                        {
                            if (projectile.frame < 3)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;
                            }
                            else if (projectile.frame > 3)
                            {
                                projectile.frame = 0;
                            }
                        }
                    }
                    else if (projectile.ai[0] > 15)
                    {
                        if (projectile.frameCounter >= 10)
                        {
                            if (projectile.frame == 3)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame = 4;
                            }
                            else if (projectile.frame < 3)
                            {
                                projectile.frame = 3;
                            }
                        }
                    }
                    else if (projectile.ai[0] > 0)
                    {
                        if (projectile.frameCounter >= 15)
                        {
                            if (projectile.frame == 4)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame = 5;
                            }
                            else if (projectile.frame == 5 && projectile.frameCounter >= 25)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame = 6;
                            }
                            else if (projectile.frame < 4)
                            {
                                projectile.frame = 4;
                            }
                        }
                    }
                    break;

                case 2: //flying towards owner
                    projectile.tileCollide = false;
                    if (distanceToIdlePosition < 240f)
                    {
                        State = 1;
                        ResetMe();
                    }

                    if (distanceToIdlePosition > 240f)
                    {
                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= 8f;
                        projectile.velocity = (projectile.velocity * (16f - 1) + vectorToIdlePosition) / 16f;
                    }

                    projectile.rotation = 0;
                    if (projectile.frameCounter >= 15)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < 7 || projectile.frame > 10)
                            projectile.frame = 7;
                    }
                    break;
            }

            projectile.friendly = foundTarget;
        }

        private void ResetMe()
        {
            projectile.ai[0] = 0;
            projectile.ai[1] = 0;
            projectile.localAI[0] = 0;
            projectile.localAI[1] = 0;
            projectile.frameCounter = 0;
            projectile.netUpdate = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (CalValEX.month == 10)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Oracle/OracleNPCPet_Pet_Halloween");
                Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[projectile.type] * projectile.frame, texture.Width, texture.Height / Main.projFrames[projectile.type]);
                Vector2 position = projectile.Center - Main.screenPosition;
                position.X += drawOffsetX;
                position.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture, position, rectangle, lightColor, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
                return false;
            }
            return true;
        }
    }
}
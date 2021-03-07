using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class SkaterPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skater Nymph");
            Main.projFrames[projectile.type] = 6; //in code it's always one less
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 12;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            drawOriginOffsetY -= 8;
        }

        /*
         * frames:
         * 0 - 1 = walking
         * 2 - 5 = flying
         */

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(isFlying);
            writer.Write(iHaveCaughtBubble);
            writer.Write(haveIFoundABubble);
            writer.Write(State);
            writer.Write(NextState);

            writer.Write(projectile.tileCollide);
            writer.Write(projectile.ignoreWater);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            isFlying = reader.ReadBoolean();
            iHaveCaughtBubble = reader.ReadBoolean();
            haveIFoundABubble = reader.ReadBoolean();
            State = reader.ReadInt32();
            NextState = reader.ReadInt32();

            projectile.tileCollide = reader.ReadBoolean();
            projectile.ignoreWater = reader.ReadBoolean();
        }

        private bool isFlying = false;
        private bool iHaveCaughtBubble = false;
        private bool haveIFoundABubble = false;
        private int State = 0;
        private int NextState = 0;

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            CalValEXPlayer modOwner = owner.GetModPlayer<CalValEXPlayer>();
            Mod calamityMod = ModLoader.GetMod("CalamityMod");

            if (!owner.active)
            {
                projectile.active = false;
                return;
            }
            if (owner.dead)
                modOwner.mSkater = false;
            if (modOwner.mSkater)
                projectile.timeLeft = 2;

            if (!isFlying)
            {
                projectile.ignoreWater = false;
                projectile.velocity.Y += 0.1f; //gravity
                projectile.velocity.X *= 0.92f; //drag
                projectile.rotation = 0;

                if (projectile.wet && projectile.velocity.Y >= 0)
                    projectile.velocity.Y -= 3f;
            }
            else
            {
                projectile.ignoreWater = true;
                projectile.rotation = projectile.velocity.X * 0.1f;
            }

            if (projectile.velocity.Y > 16f)
                projectile.velocity.Y = 16f;
            if (projectile.velocity.Y < -20f)
                projectile.velocity.Y = -20f;

            Vector2 targetCenter = owner.Center;
            Vector2 vectorToIdlePosition = targetCenter - projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();

            if (vectorToIdlePosition.Length() > 1840f)
            {
                projectile.position = targetCenter;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            float speed = 20f;
            float inertia = 80f;
            float flightSpeed = 8f;
            float flightInertia = 80f;

            if (distanceToIdlePosition > 600f)
            {
                speed = 25f;
                inertia = 70f;
                flightSpeed = 12f;
                flightInertia = 60f;
            }

            int dustID = 89; //what dust ID to use
            int dustCount = 6; //how many dust particles
            switch (State)
            {
                case -1: //flying
                    projectile.tileCollide = false;
                    //GO BACK TO WALKING IF DIDNT CATCH A BUBBLE
                    if (distanceToIdlePosition < 240f && !iHaveCaughtBubble)
                    {
                        for (int i = 0; i < dustCount; i++)
                        {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, dustID, projectile.velocity.X, projectile.velocity.Y);
                        }
                        NextState = 1;
                        isFlying = false;
                        ResetMe();
                    }

                    float offsetX = 48 * -owner.direction;
                    Vector2 offset = new Vector2(offsetX, -50f);
                    vectorToIdlePosition += offset;
                    distanceToIdlePosition = vectorToIdlePosition.Length();
                    //MOVE IF TOO FAR AWAY FROM PLAYER
                    if (distanceToIdlePosition > 20f)
                    {
                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= flightSpeed;
                        projectile.velocity = (projectile.velocity * (flightInertia - 1) + vectorToIdlePosition) / flightInertia;
                    }
                    else if (projectile.velocity == Vector2.Zero)
                    {
                        //boop it so it moves
                        projectile.velocity.X = -0.15f;
                        projectile.velocity.Y = -0.15f;
                    }
                    //ANIMATION
                    projectile.frameCounter++;
                    if (projectile.frameCounter >= 5)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame >= 6)
                            projectile.frame = 2;
                    }
                    break;

                case 0: //standing still, check if player too far away + check if there is a bubble nearby
                    projectile.tileCollide = true;
                    //IF TOO FAR AWAY FROM OWNER, MOVE
                    if (distanceToIdlePosition >= 320 && !haveIFoundABubble)
                    {
                        if (++projectile.ai[0] > 120)
                        {
                            NextState = 1;
                            ResetMe();
                        }
                    }
                    else if (projectile.ai[0] > 0)
                        projectile.ai[0]--;

                    projectile.frame = 0;

                    //SEEK BUBBLE AND DESTROY THAT BASTARD (TRANSFORM INTO CONSTANT FLYING)
                    if (calamityMod != null)
                    {
                        float bubbleDistance = float.PositiveInfinity;
                        Projectile myBubble = null;
                        for (int i = 0; i < Main.maxProjectiles; i++)
                        {
                            if ((Main.projectile[i].type == calamityMod.ProjectileType("CragmawBubble") || Main.projectile[i].type == calamityMod.ProjectileType("SulphuricAcidBubble") || Main.projectile[i].type == calamityMod.ProjectileType("SulphuricAcidBubbleFriendly") || Main.projectile[i].type == calamityMod.ProjectileType("SulphuricAcidBubble2")) && Main.projectile[i].active && Math.Abs(projectile.Center.X - Main.projectile[i].Center.X) < bubbleDistance && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.projectile[i].position, Main.projectile[i].width, Main.projectile[i].height) && Main.projectile[i].Center.Y > projectile.Bottom.Y)
                            {
                                bubbleDistance = projectile.Distance(Main.projectile[i].Center);
                                myBubble = Main.projectile[i];
                            }
                        }

                        if (bubbleDistance >= 2000f)
                            myBubble = null;
                        Vector2 bubbleCenter = owner.Center;
                        if (myBubble != null)
                        {
                            bubbleCenter = myBubble.Center;
                            haveIFoundABubble = true;
                        }
                        else
                            haveIFoundABubble = false;

                        Vector2 vectorToBubblePosition = bubbleCenter - projectile.Center;
                        float distanceToBubblePosition = vectorToBubblePosition.Length();
                        if (myBubble != null && distanceToBubblePosition < 20f)
                        {
                            projectile.velocity.Y = projectile.velocity.Y + 0.3f;
                            if (myBubble.Hitbox.Intersects(projectile.Hitbox))
                            {
                                isFlying = true;
                                iHaveCaughtBubble = true;
                                for (int i = 0; i < dustCount; i++)
                                {
                                    Dust.NewDust(projectile.position, projectile.width, projectile.height, dustID, projectile.velocity.X, projectile.velocity.Y);
                                }
                                myBubble.Kill();
                                projectile.frame = 2;
                                NextState = -1;
                                ResetMe();
                            }
                        }
                        else if (myBubble != null && distanceToBubblePosition > 20f)
                        {
                            vectorToBubblePosition.Normalize();
                            vectorToBubblePosition *= 20f;
                            projectile.velocity.X = (projectile.velocity.X * (20f - 1) + vectorToBubblePosition.X) / 20f;
                        }
                    }
                    break;

                case 1: //walking
                    projectile.tileCollide = true;
                    //TRANSFORM INTO FLYING MODE
                    if (distanceToIdlePosition >= 980)
                    {
                        for (int i = 0; i < dustCount; i++)
                        {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, dustID, projectile.velocity.X, projectile.velocity.Y);
                        }
                        NextState = -1;
                        isFlying = true;
                        ResetMe();
                    }
                    //CHECK IF STANDING STILL/NEAR PLAYER. GO BACK TO STANDING STILL ASWELL AND SEEKING BUBBLES
                    if (distanceToIdlePosition <= 160)
                    {
                        if (++projectile.ai[0] > 120)
                        {
                            NextState = 0;
                            ResetMe();
                        }
                    }
                    else if (projectile.ai[0] > 0)
                        projectile.ai[0]--;
                    // MOVE
                    if (distanceToIdlePosition > 160)
                    {
                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= speed;
                        projectile.velocity.X = (projectile.velocity.X * (inertia - 1) + vectorToIdlePosition.X) / inertia;
                    }
                    // JUMP
                    projectile.ai[1]--;
                    if (distanceToIdlePosition > 580 && (projectile.velocity.X < 2 || projectile.velocity.X > -2) && projectile.ai[1] <= 0)
                    {
                        projectile.ai[1] = 90;
                        projectile.velocity.Y -= 4.5f;
                    }
                    //ANIMATION
                    projectile.frameCounter++;
                    if ((projectile.velocity.X > 2 || projectile.velocity.X < -2) && projectile.frameCounter >= 15 && projectile.ai[1] < 30)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame > 1)
                            projectile.frame = 0;
                    }
                    else if (projectile.frameCounter >= 15 && projectile.ai[1] >= 30)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    else if ((projectile.velocity.X < 2 || projectile.velocity.X > -2) && projectile.frameCounter >= 15)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    break;
            }
            //SPRITE DIRECTION (so it faces where it moves towards)
            if (projectile.velocity.X > 0.0)
                projectile.spriteDirection = 1;
            if (projectile.velocity.X < 0.0)
                projectile.spriteDirection = -1;
        }

        private void ResetMe()
        {
            projectile.frameCounter = 0;
            projectile.ai[0] = 0;
            projectile.ai[1] = 0;
            State = NextState;
            NextState = 0;
            projectile.netUpdate = true;
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class SkaterPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Skater Nymph");
            Main.projFrames[Projectile.type] = 6; //in code it's always one less
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 12;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            DrawOriginOffsetY -= 8;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
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

            writer.Write(Projectile.tileCollide);
            writer.Write(Projectile.ignoreWater);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            isFlying = reader.ReadBoolean();
            iHaveCaughtBubble = reader.ReadBoolean();
            haveIFoundABubble = reader.ReadBoolean();
            State = reader.ReadInt32();
            NextState = reader.ReadInt32();

            Projectile.tileCollide = reader.ReadBoolean();
            Projectile.ignoreWater = reader.ReadBoolean();
        }

        private bool isFlying = false;
        private bool iHaveCaughtBubble = false;
        private bool haveIFoundABubble = false;
        private int State = 0;
        private int NextState = 0;

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            CalValEXPlayer modOwner = owner.GetModPlayer<CalValEXPlayer>();
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");

            if (!owner.active)
            {
                Projectile.active = false;
                return;
            }
            if (owner.dead)
                modOwner.mSkater = false;
            if (modOwner.mSkater)
                Projectile.timeLeft = 2;

            if (!isFlying)
            {
                Projectile.ignoreWater = false;
                Projectile.velocity.Y += 0.1f; //gravity
                Projectile.velocity.X *= 0.92f; //drag
                Projectile.rotation = 0;

                if (Projectile.wet && Projectile.velocity.Y >= 0)
                    Projectile.velocity.Y -= 3f;
            }
            else
            {
                Projectile.ignoreWater = true;
                Projectile.rotation = Projectile.velocity.X * 0.1f;
            }

            if (Projectile.velocity.Y > 16f)
                Projectile.velocity.Y = 16f;
            if (Projectile.velocity.Y < -20f)
                Projectile.velocity.Y = -20f;

            Vector2 targetCenter = owner.Center;
            Vector2 vectorToIdlePosition = targetCenter - Projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();

            if (vectorToIdlePosition.Length() > 1840f)
            {
                Projectile.position = targetCenter;
                Projectile.velocity *= 0.1f;
                Projectile.netUpdate = true;
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
                    Projectile.tileCollide = false;
                    //GO BACK TO WALKING IF DIDNT CATCH A BUBBLE
                    if (distanceToIdlePosition < 240f && !iHaveCaughtBubble)
                    {
                        for (int i = 0; i < dustCount; i++)
                        {
                            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustID, Projectile.velocity.X, Projectile.velocity.Y);
                        }
                        NextState = 1;
                        isFlying = false;
                        ResetMe();
                    }

                    float offsetX = 48 * -owner.direction;
                    Vector2 offset = new(offsetX, -50f);
                    vectorToIdlePosition += offset;
                    distanceToIdlePosition = vectorToIdlePosition.Length();
                    //MOVE IF TOO FAR AWAY FROM PLAYER
                    if (distanceToIdlePosition > 20f)
                    {
                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= flightSpeed;
                        Projectile.velocity = (Projectile.velocity * (flightInertia - 1) + vectorToIdlePosition) / flightInertia;
                    }
                    else if (Projectile.velocity == Vector2.Zero)
                    {
                        //boop it so it moves
                        Projectile.velocity.X = -0.15f;
                        Projectile.velocity.Y = -0.15f;
                    }
                    //ANIMATION
                    Projectile.frameCounter++;
                    if (Projectile.frameCounter >= 5)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame >= 6)
                            Projectile.frame = 2;
                    }
                    break;

                case 0: //standing still, check if player too far away + check if there is a bubble nearby
                    Projectile.tileCollide = true;
                    //IF TOO FAR AWAY FROM OWNER, MOVE
                    if (distanceToIdlePosition >= 320 && !haveIFoundABubble)
                    {
                        if (++Projectile.ai[0] > 120)
                        {
                            NextState = 1;
                            ResetMe();
                        }
                    }
                    else if (Projectile.ai[0] > 0)
                        Projectile.ai[0]--;

                    Projectile.frame = 0;

                    //SEEK BUBBLE AND DESTROY THAT BASTARD (TRANSFORM INTO CONSTANT FLYING)
                    /*if (calamityMod != null)
                    {
                        float bubbleDistance = float.PositiveInfinity;
                        Projectile myBubble = null;
                        for (int i = 0; i < Main.maxProjectiles; i++)
                        {
                            if ((Main.Projectile[i].type == calamityMod.ProjectileType("CragmawBubble") || Main.Projectile[i].type == calamityMod.ProjectileType("SulphuricAcidBubble") || Main.Projectile[i].type == calamityMod.ProjectileType("SulphuricAcidBubbleFriendly") || Main.Projectile[i].type == calamityMod.ProjectileType("SulphuricAcidBubble2")) && Main.Projectile[i].active && Math.Abs(Projectile.Center.X - Main.Projectile[i].Center.X) < bubbleDistance && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.Projectile[i].position, Main.Projectile[i].width, Main.Projectile[i].height) && Main.Projectile[i].Center.Y > Projectile.Bottom.Y)
                            {
                                bubbleDistance = Projectile.Distance(Main.Projectile[i].Center);
                                myBubble = Main.Projectile[i];
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

                        Vector2 vectorToBubblePosition = bubbleCenter - Projectile.Center;
                        float distanceToBubblePosition = vectorToBubblePosition.Length();
                        if (myBubble != null && distanceToBubblePosition < 20f)
                        {
                            Projectile.velocity.Y = Projectile.velocity.Y + 0.3f;
                            if (myBubble.Hitbox.Intersects(Projectile.Hitbox))
                            {
                                isFlying = true;
                                iHaveCaughtBubble = true;
                                for (int i = 0; i < dustCount; i++)
                                {
                                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustID, Projectile.velocity.X, Projectile.velocity.Y);
                                }
                                myBubble.Kill();
                                Projectile.frame = 2;
                                NextState = -1;
                                ResetMe();
                            }
                        }
                        else if (myBubble != null && distanceToBubblePosition > 20f)
                        {
                            vectorToBubblePosition.Normalize();
                            vectorToBubblePosition *= 20f;
                            Projectile.velocity.X = (Projectile.velocity.X * (20f - 1) + vectorToBubblePosition.X) / 20f;
                        }
                    }*/
                    break;

                case 1: //walking
                    Projectile.tileCollide = true;
                    //TRANSFORM INTO FLYING MODE
                    if (distanceToIdlePosition >= 980)
                    {
                        for (int i = 0; i < dustCount; i++)
                        {
                            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustID, Projectile.velocity.X, Projectile.velocity.Y);
                        }
                        NextState = -1;
                        isFlying = true;
                        ResetMe();
                    }
                    //CHECK IF STANDING STILL/NEAR PLAYER. GO BACK TO STANDING STILL ASWELL AND SEEKING BUBBLES
                    if (distanceToIdlePosition <= 160)
                    {
                        if (++Projectile.ai[0] > 120)
                        {
                            NextState = 0;
                            ResetMe();
                        }
                    }
                    else if (Projectile.ai[0] > 0)
                        Projectile.ai[0]--;
                    // MOVE
                    if (distanceToIdlePosition > 160)
                    {
                        vectorToIdlePosition.Normalize();
                        vectorToIdlePosition *= speed;
                        Projectile.velocity.X = (Projectile.velocity.X * (inertia - 1) + vectorToIdlePosition.X) / inertia;
                    }
                    // JUMP
                    Projectile.ai[1]--;
                    if (distanceToIdlePosition > 580 && (Projectile.velocity.X < 2 || Projectile.velocity.X > -2) && Projectile.ai[1] <= 0)
                    {
                        Projectile.ai[1] = 90;
                        Projectile.velocity.Y -= 4.5f;
                    }
                    //ANIMATION
                    Projectile.frameCounter++;
                    if ((Projectile.velocity.X > 2 || Projectile.velocity.X < -2) && Projectile.frameCounter >= 15 && Projectile.ai[1] < 30)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame > 1)
                            Projectile.frame = 0;
                    }
                    else if (Projectile.frameCounter >= 15 && Projectile.ai[1] >= 30)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }
                    else if ((Projectile.velocity.X < 2 || Projectile.velocity.X > -2) && Projectile.frameCounter >= 15)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }
                    break;
            }
            //SPRITE DIRECTION (so it faces where it moves towards)
            if (Projectile.velocity.X > 0.0)
                Projectile.spriteDirection = 1;
            if (Projectile.velocity.X < 0.0)
                Projectile.spriteDirection = -1;
        }

        private void ResetMe()
        {
            Projectile.frameCounter = 0;
            Projectile.ai[0] = 0;
            Projectile.ai[1] = 0;
            State = NextState;
            NextState = 0;
            Projectile.netUpdate = true;
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SkaterPet_Glow").Value;
            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw
            (
                glowMask,
                Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame,
                Color.White,
                Projectile.rotation,
                new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY),
                Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0
            );
        }
    }
}
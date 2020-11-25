using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public abstract class WalkingPet : ModProjectile
    {
        public override bool CloneNewInstances => true;

        public bool spinRotation;
        public float spinRotationSpeedMult;
        public float[] speed = new float[2];
        public float[] inertia = new float[2];
        public float[] jumpSpeed = new float[5];
        public int[] idleFrameLimits = new int[2];
        public int[] walkingFrameLimits = new int[2];
        public int[] flyingFrameLimits = new int[2];
        public int[] jumpFrameLimits = new int[2];
        public float[] animationSpeed = new float[4];
        public int jumpAnimationLength;
        public float[] distance = new float[6];
        public float gravity;
        public float[] drag = new float[2];
        public bool facingLeft;
        public bool shouldFlip;
        public bool doJumpAnim;

        /// <summary>
        /// Use this instead of SetDefaults, else the pet sprite won't work correctly.
        /// </summary>
        public virtual void SafeSetDefaults()
        {
            facingLeft = false; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false;
            shouldFlip = false;
        }

        public sealed override void SetDefaults()
        {
            doJumpAnim = true;
            SafeSetDefaults();
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
        }

        /// <summary>
        /// drag[0] is for idle drag, drag[1] is for walking drag
        /// </summary>
        public virtual void SetPetGravityAndDrag()
        {
            gravity = 0.1f; //needs to be positive for the pet to be pushed down platforms plus for it to have gravity
            drag[0] = 0.92f; //idle drag
            drag[1] = 0.95f; //walking drag
        }

        /// <summary>
        /// Each tile is 16f.
        /// distance[0] is teleport distance
        /// distance[1] is speed increase distance
        /// distance[2] is distance until it walks
        /// distance[3] is distance until it stops walking
        /// distance[4] is distance until it flies
        /// distance[5] is distance until it stops flying
        /// </summary>
        public virtual void SetPetDistances()
        {
            distance[0] = 2400f; //teleport
            distance[1] = 560f; //speed increase
            distance[2] = 320f; //when to walk
            distance[3] = 80f; //when to stop walking
            distance[4] = 448f; //when to fly
            distance[5] = 240f; //when to stop flying
        }

        /// <summary>
        /// Set speed stuff here.
        /// speed and inertia 0 (speed[0] and inertia[0]) set the walk speed and inertia, while speed and inertia 1 (speed[1] and inertia[1]) set the flying speed and inertia.
        /// </summary>
        public virtual void SetPetSpeedsAndInertia()
        {
            speed[0] = 16f; //walking speed
            speed[1] = 12f; //flying speed

            inertia[0] = 20f; //walking inertia
            inertia[1] = 80f; //flight inertia
        }

        /// <summary>
        /// jumpSpeed 0, 1, 2, 3 and 4 are 1, 2, 5, 4 and any other number of tiles
        /// </summary>
        public virtual void SetJumpSpeeds()
        {
            jumpSpeed[0] = -4f; //1 tile above pet
            jumpSpeed[1] = -6f; //2 tiles above pet
            jumpSpeed[2] = -8f; //5 tiles above pet
            jumpSpeed[3] = -7f; //4 tiles above pet
            jumpSpeed[4] = -6.5f; //any other tile number above pet
        }

        /// <summary>
        /// -1 should only be put when there is no existent min/max frame for something. if there is only one frame, do this instead:
        /// idleFrameLimits[0] = idleFrameLimits[1] = frame number;
        /// 
        /// actionFrameLimits[0] is minimum, where actionFrameLimits[1] is the max.
        /// 
        /// animationSpeed 0, 1, 2 and 3 are idle, walking, flying and jumping animation speeds respectively
        /// </summary>
        public virtual void SetFrameLimitsAndFrameSpeed()
        {
            idleFrameLimits[0] = 0; //what your min idle frame is (start of idle animation)
            idleFrameLimits[1] = 4; //what your max idle frame is (end of idle animation)

            walkingFrameLimits[0] = 5; //what your min walking frame is (start of walking animation)
            walkingFrameLimits[1] = 9; //what your max walking frame is (end of walking animation)

            flyingFrameLimits[0] = 10; //what your min flying frame is (start of flying animation)
            flyingFrameLimits[1] = 14; //what your max flying frame is (end of flying animation)

            jumpFrameLimits[0] = -1; //what your min jump frame is (start of jump animation)
            jumpFrameLimits[1] = -1; //what your max jump frame is (end of jump animation)

            animationSpeed[0] = 30; //idle animation speed
            animationSpeed[1] = 30; //walking animation speed
            animationSpeed[2] = 30; //flying animation speed
            animationSpeed[3] = -1; //jumping animation speed

            jumpAnimationLength = -1; //how long the jump animation should stay

            spinRotationSpeedMult = 1f; //how fast it should spin
        }
        
        private void SetTheseValues()
        {
            SetPetGravityAndDrag();
            SetPetDistances();
            SetJumpSpeeds();
            SetPetSpeedsAndInertia();
            SetFrameLimitsAndFrameSpeed();
        }

        //all things should be synchronized. most things vanilla already does for us, however you should sync the things you
        //made yourself as they are not synchronized alone by the server.

        public virtual void SafeSendExtraAI(BinaryWriter writer) { }
        public sealed override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(projectile.tileCollide);
            //local ai is not synchronized, as it normaly is local. however, since this is a pet, there is no harm using it like this
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]); //the state it is in, aka if its flying, walking or idling. 0 = idling, 1 = walking, 2 = flying for this example
            writer.Write(jumpCounter);

            SafeSendExtraAI(writer);
        }

        public virtual void SafeReceiveExtraAI(BinaryReader reader) { }
        public sealed override void ReceiveExtraAI(BinaryReader reader) //first in, first out. make sure the first thing you send is the first thing you read.
        {
            projectile.tileCollide = reader.ReadBoolean();
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();
            jumpCounter = reader.ReadInt32();

            SafeReceiveExtraAI(reader);
        }

        public int jumpCounter = 0; //this will determine how long the jump frame should happen
        public sealed override void AI()
        {
            SetTheseValues();
            Player owner = Main.player[projectile.owner];
            if (!owner.active)
            {
                projectile.active = false;
                return;
            }

            float offsetX = 48 * -owner.direction;
            Vector2 offset = new Vector2(offsetX, -50f);

            Vector2 vectorToOwner = owner.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (facingLeft && shouldFlip)
                projectile.spriteDirection = projectile.velocity.X > 0 ? -1 : 1;
            else if (!facingLeft && shouldFlip)
                projectile.spriteDirection = projectile.velocity.X > 0 ? 1 : -1;


            if (distanceToOwner > distance[0])
            {
                projectile.position = owner.Center;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            if (distanceToOwner > distance[1])
            {
                speed[0] *= 1.25f;
                speed[1] *= 1.25f;
                inertia[0] *= 0.75f;
                inertia[1] *= 0.75f;
            }

            switch ((int)projectile.localAI[1])
            {
                case 0: //idling
                    projectile.tileCollide = true;
                    projectile.velocity.X *= drag[0];
                    if (distanceToOwner > distance[2])
                    {
                        ResetMe();
                        projectile.localAI[1] = 1; //start walking
                    }

                    //gravity
                    projectile.velocity.Y += gravity;

                    //animation
                    projectile.frameCounter++;
                    if (projectile.frameCounter >= animationSpeed[0])
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < idleFrameLimits[0] || projectile.frame > idleFrameLimits[1])
                            projectile.frame = idleFrameLimits[0];
                    }
                    if (!spinRotation)
                    {
                        projectile.rotation = 0;
                    }
                    break;

                case 1: //walking
                    projectile.tileCollide = true;
                    projectile.velocity.X *= drag[1];
                    if (distanceToOwner < distance[3])
                    {
                        ResetMe();
                        projectile.localAI[1] = 0;
                    }
                    //check if the owner is far away, if so, go to flying
                    if (distanceToOwner > distance[4])
                    {
                        ResetMe();
                        projectile.localAI[1] = 2;
                    }

                    //gravity
                    projectile.velocity.Y += gravity;

                    //this is for tile detection
                    int i = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                    int j = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
                    if (projectile.velocity.X <= 0.1 && projectile.velocity.X >= -0.1)
                    {
                        i += projectile.direction;
                    }
                    else
                    {
                        i += (int)projectile.velocity.X;
                    }
                    //this is for jumping
                    if (doJumpAnim)
                    {
                        if (jumpCounter > -1)
                            jumpCounter--;
                    }
                    Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY);
                    if (WorldGen.SolidTile(i, j))
                    {
                        int i2 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                        int j2 = (int)(projectile.position.Y + (float)projectile.height) / 16 + 1;
                        if (WorldGen.SolidTile(i2, j2) || Main.tile[i2, j2].halfBrick() || Main.tile[i2, j2].slope() > 0)
                        {
                            try
                            {
                                i2 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                                j2 = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
                                int num = projectile.velocity.X < 0f ? 1 : -1;
                                i2 += num;
                                i2 += (int)projectile.velocity.X;

                                if (!WorldGen.SolidTile(i2, j2 - 1) && !WorldGen.SolidTile(i2, j2 - 2))
                                {
                                    projectile.velocity.Y = jumpSpeed[0];
                                    jumpCounter = jumpAnimationLength;
                                }
                                else if (!WorldGen.SolidTile(i2, j2 - 2))
                                {
                                    projectile.velocity.Y = jumpSpeed[1];
                                    jumpCounter = jumpAnimationLength;
                                }
                                else if (WorldGen.SolidTile(i2, j2 - 5))
                                {
                                    projectile.velocity.Y = jumpSpeed[2];
                                    jumpCounter = jumpAnimationLength;
                                }
                                else if (WorldGen.SolidTile(i2, j2 - 4))
                                {
                                    projectile.velocity.Y = jumpSpeed[3];
                                    jumpCounter = jumpAnimationLength;
                                }
                                else
                                {
                                    projectile.velocity.Y = jumpSpeed[4];
                                    jumpCounter = jumpAnimationLength;
                                }
                            }
                            catch
                            {
                                projectile.velocity.Y = jumpSpeed[4];
                            }
                        }
                    }

                    //this is for moving
                    vectorToOwner.Normalize();
                    vectorToOwner *= speed[0];
                    projectile.velocity.X = (projectile.velocity.X * (inertia[0] - 1) + vectorToOwner.X) / inertia[0];

                    //animation
                    projectile.frameCounter++;
                    if (projectile.frameCounter >= animationSpeed[1])
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < walkingFrameLimits[0] || projectile.frame > walkingFrameLimits[1])
                            projectile.frame = walkingFrameLimits[0];
                    }

                    //jump animation
                    if (doJumpAnim)
                    {
                        if (jumpFrameLimits[0] != -1 && jumpFrameLimits[1] != -1)
                        {
                            if (jumpCounter > 0)
                            {
                                if (projectile.frameCounter >= animationSpeed[3])
                                {
                                    if (projectile.frame == jumpFrameLimits[1])
                                    {
                                        projectile.frameCounter = 0;
                                    }
                                    projectile.frameCounter = 0;
                                    projectile.frame++;

                                    if (projectile.frame < jumpFrameLimits[0] || projectile.frame > jumpFrameLimits[1])
                                    {
                                        projectile.frame = jumpFrameLimits[0];
                                    }
                                }
                            }
                        }
                    }

                    if (!spinRotation)
                    {
                        projectile.rotation = 0;
                    }
                    break;

                case 2: //flying
                    projectile.tileCollide = false;
                    if (distanceToOwner < distance[5] && Collision.CanHit(projectile.position, projectile.width, projectile.height, owner.position, owner.width, owner.height))
                    {
                        int i3 = (int)(owner.position.X + (float)(owner.width / 2)) / 16;
                        int j3 = (int)(owner.position.Y + (float)owner.height) / 16;
                        if (WorldGen.SolidTile(i3, j3) || Main.tile[i3, j3].halfBrick() || Main.tile[i3, j3].slope() > 0 || Main.tile[i3, j3].type == TileID.Platforms)
                        {
                            projectile.localAI[1] = 1;
                            ResetMe();
                        }
                    }

                    vectorToOwner += offset;
                    distanceToOwner = vectorToOwner.Length();
                    //movement
                    if (distanceToOwner > 20f)
                    {
                        vectorToOwner.Normalize();
                        vectorToOwner *= speed[1];
                        projectile.velocity = (projectile.velocity * (inertia[1] - 1) + vectorToOwner) / inertia[1];
                    }
                    else if (projectile.velocity == Vector2.Zero)
                    {
                        //boop it so it moves
                        projectile.velocity.X = -0.15f;
                        projectile.velocity.Y = -0.15f;
                    }

                    //animation
                    projectile.frameCounter++;
                    if (projectile.frameCounter >= animationSpeed[2])
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < flyingFrameLimits[0] || projectile.frame > flyingFrameLimits[1])
                            projectile.frame = flyingFrameLimits[0];
                    }
                    if (!spinRotation)
                    {
                        projectile.rotation = projectile.velocity.X * 0.1f; //so that it turns towards where its flying
                    }
                    break;
            }

            if (spinRotation)
            {
                if (Math.Abs(projectile.velocity.X) != 0)
                {
                    float spinRotationSpeed = ((projectile.velocity.X / 20f) / 10) * spinRotationSpeedMult;
                    projectile.rotation += spinRotationSpeed;
                }
            }
        }

        public virtual void SafeAI(Player player) { }

        public override void PostAI()
        {
            SafeAI(Main.player[projectile.owner]);
        }

        public void ResetMe()
        {
            projectile.ai[0] = 0;
            projectile.ai[1] = 0;
            projectile.localAI[0] = 0;
            projectile.frameCounter = 0;
            projectile.netUpdate = true;
        }
    }
}


using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using System;

namespace CalValEX.Projectiles.Pets
{
    public class Ebonian : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonian Slime Demigod");
            Main.projFrames[projectile.type] = 7; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 30;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            base.drawOffsetX = 6;
            base.drawOriginOffsetY = 8;
        }

        //all things should be synchronized. most things vanilla already does for us, however you should sync the things you
        //made yourself as they are not synchronized alone by the server.
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(projectile.tileCollide);
            //local ai is not synchronized, as it normaly is local. however, since this is a pet, there is no harm using it like this
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]); //the state it is in, aka if its flying, walking or idling. 0 = idling, 1 = walking, 2 = flying for this example
            writer.Write(jumpCounter);
        }

        public override void ReceiveExtraAI(BinaryReader reader) //first in, first out. make sure the first thing you send is the first thing you read.
        {
            projectile.tileCollide = reader.ReadBoolean();
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();
            jumpCounter = reader.ReadInt32();
        }

        private int jumpCounter = 0; //this will determine how long the jump frame should happen
        public override void AI()
        {
            //this can also be a only flying pet, go below and search for the bool onlyFlying.
            Player owner = Main.player[projectile.owner];
            if (!owner.active)
            {
                projectile.active = false;
                return;
            }

            {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.eb = false;
            }
            if (modPlayer.eb)
            {
                projectile.timeLeft = 2;
            }
        }

            //this is heavely uneeded. you could just replace all these values with proper values inside the code, however
            //for simplicity sake, i put them like this for you to easely manipulate each thing without needing to go into the code.

            bool onlyFlying = false; //should the pet only fly?

            float[] speed = new float[2]; //speed of the pet
            speed[0] = 22f; //walking speed
            speed[1] = 10f; //flight speed

            float[] inertia = new float[2]; //makes it so that the pet is 'innacurate' with how it moves (i myself dont know what it does, just does a thing that it should)
            inertia[0] = 20f; //walking inertia
            inertia[1] = 80f; //flight inertia

            float[] jumpSpeed = new float[5]; //how high the pet should jump in each case. put negative in here so that it jumps up
            jumpSpeed[0] = -4f; //1 tile above pet
            jumpSpeed[1] = -6f; //2 tiles above pet
            jumpSpeed[2] = -8f; //5 tiles above pet
            jumpSpeed[3] = -7f; //4 tiles above pet
            jumpSpeed[4] = -6.5f; //any other tile number above pet

            //--------------------------------------------------------------------------------
            //-1 should only be put when there is no existent min/max frame for something. if there is only one frame, do this instead:
            //idleFrameLimits[0] = idleFrameLimits[1] = frame number;
            int[] idleFrameLimits = new int[2];
            idleFrameLimits[0] = 0;
            idleFrameLimits[1] = 1;

            int[] walkingFrameLimits = new int[2];
            walkingFrameLimits[0] = 0; //what your min walking frame is (start of walking animation)
            walkingFrameLimits[1] = 3; //what your max walking frame is (end of walking animation)

            int[] flyingFrameLimits = new int[2];
            flyingFrameLimits[0] = 4;
            flyingFrameLimits[1] = 6; //what your min flying frame is (start of flying animation)

            int[] jumpFrameLimits = new int[2];
            jumpFrameLimits[0] = -1; //what your min jump frame is (start of jump animation)
            jumpFrameLimits[1] = -1; //what your max jump frame is (end of jump animation

            //--------------------------------------------------------------------------------

            float[] animationSpeed = new float[4]; //how fast the animation should play
            animationSpeed[0] = 10; //idle animation speed
            animationSpeed[1] = 5; //walking animation speed
            animationSpeed[2] = 5; //flying animation speed
            animationSpeed[3] = -1; //jumping animation speed

            int jumpAnimationLength = -1; //how long the jump animation should stay

            //--------------------------------------------------------------------------------
            //each tile is 16f, multiply it by how much you want till the pet does something
            float[] distance = new float[6];
            distance[0] = 1840f; //teleport
            distance[1] = 560f; //speed increase
            distance[2] = 320f; //when to walk
            distance[3] = 80f; //when to stop walking
            distance[4] = 360f; //when to fly
            distance[5] = 240f; //when to stop flying

            //--------------------------------------------------------------------------------

            float gravity = 0.1f; //needs to be positive for the pet to be pushed down platforms plus for it to have gravity
            float[] drag = new float[2]; //friction on ground, for it to stop moving/sliding. these should always be between 1f and 0.80f.
            drag[0] = 0.92f; //idle drag
            drag[1] = 0.95f; //walking drag

            //how do you know what speed is right? you just have to test out different values. same for inertia

            //--------------------------------------------------------------------------------

            //flying offset, so that it flys behind and a little above the player
            float offsetX = 48 * -owner.direction;
            Vector2 offset = new Vector2(offsetX, -50f);

            //--------------------------------------------------------------------------------

            Vector2 vectorToOwner = owner.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            //here we make the projectile image flip depending what their velocity is.
            //this depends where the sprite is facing initialy (on the sprite).
            //if the sprite is directed towards the right (facing right on the sprite), it should be this:
            projectile.spriteDirection = projectile.velocity.X > 0 ? 1 : -1;
            //however, if the sprite is directed towards the left (facing left on the sprite), it should be the example below (uncomment the below and comment the above if that is the case):
            //projectile.spriteDirection = projectile.velocity.X > 0 ? -1 : 1;

            //this teleports the pet to the player
            if (distanceToOwner > distance[0]) //when to teleport
            {
                projectile.position = owner.Center;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            //makes the pet faster when too far away
            if (distanceToOwner > distance[1]) //when 35 tiles away
            {
                //you can also just apply a new thing via speed[0] = numberf, for example
                speed[0] *= 1.25f;
                speed[1] /= 1.25f;
                inertia[0] *= 1.25f;
                inertia[1] /= 1.25f;
            }

            if (onlyFlying)
            {
                projectile.localAI[1] = 2;
            }

            switch ((int)projectile.localAI[1])
            {
                case 0: //idling
                    projectile.tileCollide = true;
                    projectile.velocity.X *= drag[0]; //drag
                    //check if player is away for a certain amount of tiles
                    if (distanceToOwner > distance[2]) //20 tiles
                    {
                        ResetMe();
                        projectile.localAI[1] = 1; //start walking
                    }

                    //gravity
                    projectile.velocity.Y += gravity;

                    //animation
                    projectile.frameCounter++;
                    if (projectile.frameCounter >= animationSpeed[0]) //each frame in the game is a tick. change 15 to how fast you want it to change sprites
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < idleFrameLimits[0] || projectile.frame > idleFrameLimits[1])
                            projectile.frame = idleFrameLimits[0];
                    }
                    projectile.rotation = 0;
                    break;

                case 1: //walking
                    projectile.tileCollide = true;
                    projectile.velocity.X *= drag[1]; //drag
                    //check if the owner is nearby, if so, go back to idling
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
                    if (jumpCounter > -1)
                        jumpCounter--;
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
                                    jumpCounter = 15;
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
                    if (jumpFrameLimits[0] != -1 && jumpFrameLimits[1] != -1)
                    {
                        if (jumpCounter > 0)
                        {
                            if (projectile.frameCounter >= animationSpeed[3])
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;
                                if (projectile.frame < jumpFrameLimits[0] || projectile.frame > jumpFrameLimits[1])
                                    projectile.frame = jumpFrameLimits[0];
                            }
                        }
                    }

                    projectile.rotation = 0;
                    break;

                case 2: //flying
                    projectile.tileCollide = false;
                    if (distanceToOwner < distance[5] && !onlyFlying)
                    {
                        projectile.localAI[1] = 1;
                        ResetMe();
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
                    projectile.rotation = projectile.velocity.X * 0.1f; //so that it turns towards where its flying
                    break;
            }
        }

        private void ResetMe()
        {
            projectile.ai[0] = 0;
            projectile.ai[1] = 0;
            projectile.localAI[0] = 0;
            projectile.frameCounter = 0;
            projectile.netUpdate = true;
        }
    }
}

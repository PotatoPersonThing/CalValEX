using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class Junko : WalkingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lil Junko");
            Main.projFrames[Projectile.type] = 13; //frames
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 126;
            Projectile.height = 74;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            DrawOriginOffsetY = 2;
            Projectile.tileCollide = true;
            facingLeft = true; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true;
        }

        //all things should be synchronized. most things vanilla already does for us, however you should sync the things you
        //made yourself as they are not synchronized alone by the server.
        public override void SetPetGravityAndDrag()
        {
            gravity = 0.1f; //needs to be positive for the pet to be pushed down platforms plus for it to have gravity
            drag[0] = 0.92f; //idle drag
            drag[1] = 0.95f; //walking drag
        }

        public override void SetPetDistances()
        {
            distance[0] = 2400f; //teleport
            distance[1] = 560f; //speed increase
            distance[2] = 140f; //when to walk
            distance[3] = 40f; //when to stop walking
            distance[4] = 448f; //when to fly
            distance[5] = 180f; //when to stop flying
        }

        public override void SetPetSpeedsAndInertia()
        {
            speed[0] = 10f; //walking speed
            speed[1] = 12f; //flying speed

            inertia[0] = 20f; //walking inertia
            inertia[1] = 80f; //flight inertia
        }

        public override void SetJumpSpeeds()
        {
            jumpSpeed[0] = -4f; //1 tile above pet
            jumpSpeed[1] = -6f; //2 tiles above pet
            jumpSpeed[2] = -8f; //5 tiles above pet
            jumpSpeed[3] = -7f; //4 tiles above pet
            jumpSpeed[4] = -6.5f; //any other tile number above pet
        }

        public override void SetFrameLimitsAndFrameSpeed()
        {
            idleFrameLimits[0] = idleFrameLimits[1] = 1; //what your min idle frame is (start of idle animation)

            walkingFrameLimits[0] = 0; //what your min walking frame is (start of walking animation)
            walkingFrameLimits[1] = 1; //what your max walking frame is (end of walking animation)

            flyingFrameLimits[0] = 2; //what your min flying frame is (start of flying animation)
            flyingFrameLimits[1] = 5; //what your max flying frame is (end of flying animation)

            animationSpeed[0] = 8; //idle animation speed
            animationSpeed[1] = 8; //walking animation speed
            animationSpeed[2] = 7; //flying animation speed
            spinRotationSpeedMult = 2.5f; //how fast it should spin
            //put the below to -1 if you dont want a jump animation (so its just gonna continue it's walk animation
            animationSpeed[3] = -1; //jumping animation speed

            jumpFrameLimits[0] = -1; //what your min jump frame is (start of jump animation)
            jumpFrameLimits[1] = -1; //what your max jump frame is (end of jump animation)

            jumpAnimationLength = -1; //how long the jump animation should stay
        }
        int sigcounter;
        int basetime = 30;
        private bool signut = false;
        private bool dust = false;
        private bool sound = false;
        private bool finished = false;
        private bool teleported = false;
        float sigposx;
        float sigposy;
        int sigdirection;

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.junsi = false;
            if (modPlayer.junsi)
                Projectile.timeLeft = 2;

            /* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
             * for custom behaviour, you can check if the projectile is walking or not via Projectile.localAI[1]
             * you should make new custom behaviour with numbers higher than 2, or less than 0
             * the next few lines is an example on how to implement this
             *
             * switch ((int)Projectile.localAI[1])
             * {
             *     case -1:
             *         break;
             *     case 3:
             *         break;
             * }
             *
             * 0, 1 and 2 are already in use.
             * 0 = idling
             * 1 = walking
             * 2 = flying
             *
             * you can still use these, changing thing inside (however it's not recomended unless you want to add custom behaviour to these)
             */
            for (int x = 0; x < Main.maxNPCs; x++)
            {
                NPC npc = Main.npc[x];
                if (npc.type == NPCID.Wraith && npc.life == 1 && npc.active)
                {
                    sigdirection = npc.spriteDirection;
                    sigposx = npc.Center.X;
                    sigposy = npc.position.Y;
                    signut = true;
                    //Projectile.frame = 6;
                    Projectile.localAI[1] = 3;
                }
            }
            if (Projectile.localAI[1] == 3 && !finished/* && !Program.IsServer*/)
            {
                Projectile.tileCollide = false;
                Projectile.rotation = 0;
                //Framing
                if (sigcounter < basetime + 6)
                {
                    Projectile.frame = 6;
                    Projectile.velocity.X = 0;
                }
                else if (sigcounter >= basetime + 6 && sigcounter < basetime + 12)
                {
                    Projectile.frame = 7;
                }
                else if (sigcounter >= basetime + 12 && sigcounter < basetime + 18)
                {
                    Projectile.frame = 8;
                }
                else if (sigcounter >= basetime + 18 && sigcounter < basetime + 24)
                {
                    Projectile.frame = 9;
                }
                else if (sigcounter >= basetime + 24 && sigcounter < basetime + 30)
                {
                    Projectile.frame = 10;
                }
                else if (sigcounter > basetime + 30 && sigcounter <= basetime + 40)
                {
                    Projectile.frame = 11;
                }
                else if (sigcounter > basetime + 40 && sigcounter <= basetime + 50)
                {
                    Projectile.frame = 12;
                }
                else
                {
                    Projectile.frame = 6;
                }
                //Attack
                if (sigcounter <= basetime + 30)
                {
                    if (sigcounter == 0 || sigcounter == 1)
                    {
                        if (!dust)
                        {
                            for (int a = 0; a < 20; a++)
                            {
                                Dust dust2;
                                dust2 = Main.dust[Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 173, 0f, 0f, 0, new Color(255, 255, 255), 1.4f)];
                            }
                            if (sigcounter > 0)
                            {
                                dust = true;
                            }
                        }
                    }
                    if (!teleported)
                    {
                        Projectile.direction = sigdirection;
                        Projectile.spriteDirection = sigdirection;
                        Projectile.position.Y = sigposy + 5;
                        Projectile.position.X = sigposx + 40; // (sigdirection == -1 ? 40 : -200);
                        teleported = true;
                    }
                    Projectile.velocity.Y = -0.1f;
                    gravity = 0f;
                }
                else if (sigcounter > basetime + 30 && sigcounter <= basetime + 40)
                {
                    if (!sound)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item109);
                        sound = true;
                    }
                    Projectile.velocity.X = 20 * sigdirection;
                    gravity = 0.05f * sigcounter;
                }
                else if (sigcounter > basetime + 50)
                {
                    Projectile.localAI[1] = 2;
                    gravity = 0.1f;
                    finished = true;
                }
                else
                {
                    Projectile.localAI[1] = 2;
                }
                if (finished)
                {
                    Projectile.localAI[1] = 2;
                }
            }
            if (Projectile.localAI[1] == 3 && finished)
            {
                Projectile.localAI[1] = 2;
            }
            if (Projectile.localAI[1] != 3)
            {
                sigcounter = -1;
                dust = false;
                signut = false;
                sound = false;
                finished = false;
                teleported = false;
            }
            if (signut)
            {
                sigcounter++;
            }
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/Junko_Glow").Value;
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

        public override void SafeSendExtraAI(BinaryWriter writer)
        {
            writer.Write(sigcounter);
            writer.Write(basetime);
            writer.Write(sigdirection);
            writer.Write(sigposx);
            writer.Write(sigposy);
            writer.Write(signut);
            writer.Write(dust);
            writer.Write(sound);
            writer.Write(teleported);
            writer.Write(finished);
        }
        public override void SafeReceiveExtraAI(BinaryReader reader)
        {
            signut = reader.ReadBoolean();
            dust = reader.ReadBoolean();
            sound = reader.ReadBoolean();
            teleported = reader.ReadBoolean();
            finished = reader.ReadBoolean();
            sigcounter = reader.ReadInt32();
            basetime = reader.ReadInt32();
            sigdirection = reader.ReadInt32();
            sigposx = reader.ReadInt32();
            sigposy = reader.ReadInt32();
        }
    }
}
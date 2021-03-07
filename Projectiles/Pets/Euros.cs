using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Euros : WalkingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chibii Euros");
            Main.projFrames[projectile.type] = 25;
            Main.projPet[projectile.type] = true;
        }

        private readonly string auraTexture = "Projectiles/Pets/ChibiiEuros_Aura";
        private readonly int auraFrames = 4;

        public override void SafeSetDefaults()
        {
            projectile.width = 22;
            projectile.height = 26;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            facingLeft = false;
            spinRotation = false;
            shouldFlip = true;
            drawOffsetX = -15;
            drawOriginOffsetY -= 21;
        }

        public override void SetFrameLimitsAndFrameSpeed()
        {
            idleFrameLimits[0] = idleFrameLimits[1] = 0;
            walkingFrameLimits[0] = 1;
            walkingFrameLimits[1] = 4;

            flyingFrameLimits[0] = 0;
            flyingFrameLimits[1] = 0;

            animationSpeed[0] = 30;
            animationSpeed[1] = 7;
            animationSpeed[2] = 2;
            spinRotationSpeedMult = 0f;
            animationSpeed[3] = 5;

            jumpFrameLimits[0] = 5;
            jumpFrameLimits[1] = 8;

            jumpAnimationLength = 60;
        }

        public override void SetPetDistances()
        {
            distance[0] = 1200f; //since we wont fly, make the teleport distance to half of normal.
            distance[1] = 560f;
            distance[2] = 320f;
            distance[3] = 80f;
            //we will never fly.
            distance[4] = float.MaxValue;
            distance[5] = float.MaxValue - 1f;
        }

        public override void SetJumpSpeeds()
        {
            //higher jump.
            jumpSpeed[0] = -5.25f;
            jumpSpeed[1] = -7.25f;
            jumpSpeed[2] = -9.25f;
            jumpSpeed[3] = -8.25f;
            jumpSpeed[4] = -7.75f;
        }

        public override void SafeSendExtraAI(BinaryWriter writer)
        {
            writer.Write(auraFrame);
        }

        public override void SafeReceiveExtraAI(BinaryReader reader)
        {
            auraFrame = reader.ReadInt32();
        }

        /* Frames:
         * 0: idle
         * 1 - 4: walking
         * 5 - 8: jumping
         * 9 - 12: transforming to meditation
         * 13 - 24: meditating
         */

        private int auraFrame;

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.euros = false;
            if (modPlayer.euros)
                projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            switch ((int)projectile.localAI[1])
            {
                case -1: //meditate
                    if (distanceToOwner >= distance[2])
                    {
                        projectile.localAI[1] = 1;
                        ResetMe();
                    }

                    projectile.ai[1]++;
                    if (projectile.ai[1] >= 20)
                    {
                        projectile.ai[1] = 0;
                        auraFrame++;
                        if (auraFrame > auraFrames - 1)
                            auraFrame = 0;
                    }

                    projectile.frameCounter++;
                    switch ((int)projectile.ai[0])
                    {
                        case 0:
                            if (projectile.frameCounter >= 15)
                            {
                                if (projectile.frame == 12)
                                {
                                    projectile.frameCounter = 0;
                                    projectile.ai[0] = 1;
                                    break;
                                }
                                projectile.frameCounter = 0;
                                projectile.frame++;
                                if (projectile.frame < 9)
                                {
                                    projectile.frame = 9;
                                }
                            }
                            break;

                        case 1:
                            if (projectile.frameCounter >= 5)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;
                                if (projectile.frame < 13 || projectile.frame > 24)
                                {
                                    projectile.frame = 13;
                                }
                            }
                            break;
                    }
                    break;

                case 0: //when to mediate
                    if (++projectile.ai[0] >= 240)
                    {
                        projectile.localAI[1] = -1;
                        ResetMe();
                    }
                    break;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.localAI[1] == -1)
            {
                Texture2D texture = mod.GetTexture(auraTexture);
                Rectangle sourceRectangle = new Rectangle(0, 46 * auraFrame, texture.Width, texture.Height / auraFrames);
                Vector2 origin = new Vector2(texture.Width, texture.Height / auraFrames);
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, sourceRectangle, Color.White, 0f, origin / 2f, 1f, SpriteEffects.None, 0);
            }
            return true;
        }
    }
}
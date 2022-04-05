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
            Main.projFrames[Projectile.type] = 25;
            Main.projPet[Projectile.type] = true;
        }

        private readonly string auraTexture = "CalValEX/Projectiles/Pets/ChibiiEuros_Aura";
        private readonly int auraFrames = 4;

        public override void SafeSetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 26;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            facingLeft = false;
            spinRotation = false;
            shouldFlip = true;
            DrawOffsetX = -15;
            DrawOriginOffsetY -= 21;
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
                Projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            switch ((int)Projectile.localAI[1])
            {
                case -1: //meditate
                    if (distanceToOwner >= distance[2])
                    {
                        Projectile.localAI[1] = 1;
                        ResetMe();
                    }

                    Projectile.ai[1]++;
                    if (Projectile.ai[1] >= 20)
                    {
                        Projectile.ai[1] = 0;
                        auraFrame++;
                        if (auraFrame > auraFrames - 1)
                            auraFrame = 0;
                    }

                    Projectile.frameCounter++;
                    switch ((int)Projectile.ai[0])
                    {
                        case 0:
                            if (Projectile.frameCounter >= 15)
                            {
                                if (Projectile.frame == 12)
                                {
                                    Projectile.frameCounter = 0;
                                    Projectile.ai[0] = 1;
                                    break;
                                }
                                Projectile.frameCounter = 0;
                                Projectile.frame++;
                                if (Projectile.frame < 9)
                                {
                                    Projectile.frame = 9;
                                }
                            }
                            break;

                        case 1:
                            if (Projectile.frameCounter >= 5)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;
                                if (Projectile.frame < 13 || Projectile.frame > 24)
                                {
                                    Projectile.frame = 13;
                                }
                            }
                            break;
                    }
                    break;

                case 0: //when to mediate
                    if (++Projectile.ai[0] >= 240)
                    {
                        Projectile.localAI[1] = -1;
                        ResetMe();
                    }
                    break;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.localAI[1] == -1)
            {
                Texture2D texture = Terraria.ModLoader.ModContent.Request<Texture2D>(auraTexture).Value;
                Rectangle sourceRectangle = new Rectangle(0, 46 * auraFrame, texture.Width, texture.Height / auraFrames);
                Vector2 origin = new Vector2(texture.Width, texture.Height / auraFrames);
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.White, 0f, origin / 2f, 1f, SpriteEffects.None, 0);
            }
            return true;
        }
    }
}
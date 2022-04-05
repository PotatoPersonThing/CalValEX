using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class ClamHermit : WalkingPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/ClamHermit_Normal";
        private readonly string HalloweenTexture = "CalValEX/Projectiles/Pets/ClamHermit_Halloween";
        private readonly string ChristmasTexture = "CalValEX/Projectiles/Pets/ClamHermit_Christmas";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clam Hermit");
            Main.projFrames[Projectile.type] = 15;
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 26;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            facingLeft = false;
            spinRotation = false;
            shouldFlip = true;
            DrawOffsetX -= 1;
            DrawOriginOffsetY -= 4;
            doJumpAnim = false;
        }

        public override void SetPetGravityAndDrag()
        {
            gravity = 0.1f;
            drag[0] = 0.92f;
            drag[1] = 0.95f;
        }

        public override void SetPetDistances()
        {
            distance[0] = 2400f;
            distance[1] = 560f;
            distance[2] = 140f;
            distance[3] = 40f;
            distance[4] = 448f;
            distance[5] = 180f;
        }

        public override void SetPetSpeedsAndInertia()
        {
            speed[0] = 10f;
            speed[1] = 12f;

            inertia[0] = 20f;
            inertia[1] = 80f;
        }

        public override void SetJumpSpeeds()
        {
            jumpSpeed[0] = -4f;
            jumpSpeed[1] = -6f;
            jumpSpeed[2] = -8f;
            jumpSpeed[3] = -7f;
            jumpSpeed[4] = -6.5f;
        }

        public override void SetFrameLimitsAndFrameSpeed()
        {
            idleFrameLimits[0] = idleFrameLimits[1] = 0;

            walkingFrameLimits[0] = 0;
            walkingFrameLimits[1] = 5;

            flyingFrameLimits[0] = 6;
            flyingFrameLimits[1] = 6;

            animationSpeed[0] = 30;
            animationSpeed[1] = 8;
            animationSpeed[2] = 10;
            spinRotationSpeedMult = 2.5f;
            animationSpeed[3] = 5;

            jumpFrameLimits[0] = 7; //min frame
            jumpFrameLimits[1] = 9; //max frame

            jumpAnimationLength = 60; //how long the jump animation should stay
        }

        public override bool PreDraw(ref Color lightColor)
        {
            if (CalValEX.month == 10 || Main.halloween)
            {
                Texture2D texture = ModContent.Request<Texture2D>(HalloweenTexture).Value;
                Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture.Width, texture.Height / Main.projFrames[Projectile.type]);
                Vector2 position = Projectile.Center - Main.screenPosition;
                position.X += DrawOffsetX;
                position.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture, position, rectangle, lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                return false;
            }
            if (CalValEX.month == 12 || Main.xMas)
            {
                Texture2D texture = ModContent.Request<Texture2D>(ChristmasTexture).Value;
                Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture.Width, texture.Height / Main.projFrames[Projectile.type]);
                Vector2 position = Projectile.Center - Main.screenPosition;
                position.X += DrawOffsetX;
                position.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture, position, rectangle, lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                return false;
            }
            return true;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mClam = false;
            if (modPlayer.mClam)
                Projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            switch ((int)Projectile.localAI[1])
            {
                case -1: //jaming
                    if (distanceToOwner > distance[2])
                    {
                        Projectile.localAI[1] = 1;
                        ResetMe();
                    }

                    Projectile.frameCounter++;
                    if (Projectile.frameCounter > 10)
                    {
                        Projectile.frame++;
                        Projectile.frameCounter = 0;
                        if (Projectile.frame < 11 || Projectile.frame > 14)
                            Projectile.frame = 11;
                    }
                    break;

                case 0:
                    if (Projectile.ai[0]++ > 240)
                    {
                        Projectile.localAI[1] = -1;
                        ResetMe();
                    }
                    break;

                case 1:
                    if (jumpCounter > 0)
                        jumpCounter--;
                    if (jumpFrameLimits[0] != -1 && jumpFrameLimits[1] != -1)
                    {
                        if (jumpCounter > 0)
                        {
                            if (Projectile.frameCounter >= animationSpeed[3])
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;

                                if (Projectile.frame >= jumpFrameLimits[1])
                                    Projectile.frame = jumpFrameLimits[1] - 1;
                            }
                        }
                    }
                    break;
            }

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
        }
    }
}
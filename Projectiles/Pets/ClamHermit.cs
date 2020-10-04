using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class ClamHermit : WalkingPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/ClamHermit_Normal";
        private readonly string HalloweenTexture = "CalValEX/Projectiles/Pets/ClamHermit_Halloween";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clam Hermit");
            Main.projFrames[projectile.type] = 15;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 20;
            projectile.height = 26;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            facingLeft = false;
            spinRotation = false;
            shouldFlip = true;
            drawOffsetX -= 1;
            drawOriginOffsetY -= 4;
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

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (CalValEX.month == 10)
            {
                Texture2D texture = ModContent.GetTexture(HalloweenTexture);
                Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[projectile.type] * projectile.frame, texture.Width, texture.Height / Main.projFrames[projectile.type]);
                Vector2 position = projectile.Center - Main.screenPosition;
                position.X += drawOffsetX;
                position.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture, position, rectangle, lightColor, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);
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
                projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            switch ((int)projectile.localAI[1])
            {
                case -1: //jaming
                    if (distanceToOwner > distance[2])
                    {
                        projectile.localAI[1] = 1;
                        ResetMe();
                    }

                    projectile.frameCounter++;
                    if (projectile.frameCounter > 10)
                    {
                        projectile.frame++;
                        projectile.frameCounter = 0;
                        if (projectile.frame < 11 || projectile.frame > 14)
                            projectile.frame = 11;
                    }
                    break;
                case 0:
                    if (projectile.ai[0]++ > 240)
                    {
                        projectile.localAI[1] = -1;
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
                            if (projectile.frameCounter >= animationSpeed[3])
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;

                                if (projectile.frame >= jumpFrameLimits[1])
                                    projectile.frame = jumpFrameLimits[1] - 1;
                            }
                        }
                    }
                    break;
            }

            /* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
             * for custom behaviour, you can check if the projectile is walking or not via projectile.localAI[1]
             * you should make new custom behaviour with numbers higher than 2, or less than 0
             * the next few lines is an example on how to implement this
             * 
             * switch ((int)projectile.localAI[1])
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

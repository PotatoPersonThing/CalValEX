using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Euros : ModWalkingPet
    {
        public new class States
        {
            public const int Meditating = -1;
            public const int Walking = 0;
            public const int Flying = 1;
        }

        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1200f;

        public override bool CanFly => false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chibii Euros");
            Main.projFrames[projectile.type] = 25;
            Main.projPet[projectile.type] = true;
        }

        private readonly string auraTexture = "Projectiles/Pets/ChibiiEuros_Aura";
        private const int auraFrames = 4;

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 22;
            projectile.height = 26;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOffsetX = -15;
            drawOriginOffsetY -= 21;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (projectile.velocity.Y != 0f) // jump
                    {
                        if (projectile.velocity.Y < 0f)
                        {
                            if (++projectile.frameCounter > 8)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;
                                if (projectile.frame < 5)
                                    projectile.frame = 5;
                                if (projectile.frame > 6)
                                    projectile.frame = 6;
                            }
                        }
                        else if (projectile.velocity.Y > 0f)
                        {
                            if (++projectile.frameCounter > 8)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;

                                if (projectile.frame < 7)
                                    projectile.frame = 7;
                                if (projectile.frame > 8)
                                    projectile.frame = 8;
                            }
                        }
                    }
                    else
                    {
                        if (projectile.velocity.X != 0f)
                        {
                            if (++projectile.frameCounter > 7)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;

                                if (projectile.frame > 4 || projectile.frame < 1)
                                    projectile.frame = 1;
                            }
                        }
                        else
                        {
                            projectile.frame = 0;
                            projectile.frameCounter = 0;
                        }
                    }
                    break;
            }
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -5.25f;
            twoTilesHigher = -7.25f;
            fiveTilesHigher = -9.25f;
            fourTilesHigher = -8.25f;
            anyOtherJump = -7.65f;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(auraFrame);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            auraFrame = reader.ReadInt32();
            base.ReceiveExtraAI(reader);
        }

        /* Frames:
         * 0: idle
         * 1 - 4: walking
         * 5 - 8: jumping
         * 9 - 12: transforming to meditation
         * 13 - 24: meditating
         */

        private int auraFrame;

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.euros = false;

            if (modPlayer.euros)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            projectile.ai[1]++;
            if (projectile.ai[1] >= 20)
            {
                projectile.ai[1] = 0;
                auraFrame++;
                if (auraFrame > auraFrames - 1)
                    auraFrame = 0;
            }

            switch (state)
            {
                case States.Meditating: //meditate
                    if (distanceToOwner >= WalkingThreshold * 2.5f)
                    {
                        ResetMe(States.Walking);
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

                case States.Walking: //when to mediate
                    if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f && player.velocity.X == 0f && player.velocity.Y == 0 && distanceToOwner < WalkingThreshold)
                    {
                        if (++projectile.ai[0] >= 240)
                        {
                            ResetMe(States.Meditating);
                        }
                    }
                    else
                    {
                        projectile.ai[0] -= 2;
                        if (projectile.ai[0] < 0)
                            projectile.ai[0] = 0;
                    }
                    break;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = mod.GetTexture(auraTexture);
            Rectangle sourceRectangle = new Rectangle(0, 46 * auraFrame, texture.Width, texture.Height / auraFrames);
            Vector2 origin = new Vector2(texture.Width, texture.Height / auraFrames);
            SpriteEffects spriteEffects = SpriteEffects.None;
            Vector2 offset = new Vector2(-4f, 0);

            if (projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
                offset.X += 8f; 
            }

            if (state != States.Meditating)
                offset.Y -= +10f;

            spriteBatch.Draw(texture, projectile.Center + offset - Main.screenPosition, sourceRectangle, Color.White, 0f, origin / 2f, 1f, spriteEffects, 0);
            return true;
        }
    }
}
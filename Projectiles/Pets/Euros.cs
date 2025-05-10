using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ModLoader;

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
            // DisplayName.SetDefault("Chibii Euros");
            Main.projFrames[Projectile.type] = 25;
            Main.projPet[Projectile.type] = true;
        }

        private readonly string auraTexture = "CalValEX/Projectiles/Pets/ChibiiEuros_Aura";
        private const int auraFrames = 4;

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 26;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOffsetX = -15;
            DrawOriginOffsetY -= 21;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (Projectile.velocity.Y != 0f) // jump
                    {
                        if (Projectile.velocity.Y < 0f)
                        {
                            if (++Projectile.frameCounter > 8)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;
                                if (Projectile.frame < 5)
                                    Projectile.frame = 5;
                                if (Projectile.frame > 6)
                                    Projectile.frame = 6;
                            }
                        }
                        else if (Projectile.velocity.Y > 0f)
                        {
                            if (++Projectile.frameCounter > 8)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;

                                if (Projectile.frame < 7)
                                    Projectile.frame = 7;
                                if (Projectile.frame > 8)
                                    Projectile.frame = 8;
                            }
                        }
                    }
                    else
                    {
                        if (Projectile.velocity.X != 0f)
                        {
                            if (++Projectile.frameCounter > 7)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;

                                if (Projectile.frame > 4 || Projectile.frame < 1)
                                    Projectile.frame = 1;
                            }
                        }
                        else
                        {
                            Projectile.frame = 0;
                            Projectile.frameCounter = 0;
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
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            Vector2 vectorToOwner = player.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            Projectile.ai[1]++;
            if (Projectile.ai[1] >= 20)
            {
                Projectile.ai[1] = 0;
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

                case States.Walking: //when to mediate
                    if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f && player.velocity.X == 0f && player.velocity.Y == 0 && distanceToOwner < WalkingThreshold)
                    {
                        if (++Projectile.ai[0] >= 240)
                        {
                            ResetMe(States.Meditating);
                        }
                    }
                    else
                    {
                        Projectile.ai[0] -= 2;
                        if (Projectile.ai[0] < 0)
                            Projectile.ai[0] = 0;
                    }
                    break;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(auraTexture).Value;
            Rectangle sourceRectangle = new(0, 46 * auraFrame, texture.Width, texture.Height / auraFrames);
            Vector2 origin = new(texture.Width, texture.Height / auraFrames);
            SpriteEffects spriteEffects = SpriteEffects.None;
            Vector2 offset = new(-4f, 0);

            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
                offset.X += 8f; 
            }

            if (state != States.Meditating)
                offset.Y -= +10f;

            Main.EntitySpriteDraw(texture, Projectile.Center + offset - Main.screenPosition, sourceRectangle, Color.White, 0f, origin / 2f, 1f, spriteEffects, 0);
            return true;
        }
    }
}
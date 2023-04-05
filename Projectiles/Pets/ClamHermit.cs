using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class ClamHermit : ModWalkingPet
    {
        public new class States
        {
            public const int Jamming = -1;
            public const int Walking = 0;
            public const int Flying = 1;
        }

        public override string Texture => "CalValEX/Projectiles/Pets/ClamHermit_Normal";
        private readonly string HalloweenTexture = "CalValEX/Projectiles/Pets/ClamHermit_Halloween";
        private readonly string ChristmasTexture = "CalValEX/Projectiles/Pets/ClamHermit_Christmas";

        public override bool FacesLeft => false;

        public override int JumpOffset => 10;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Clam Hermit");
            Main.projFrames[Projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 20;
            Projectile.height = 26;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOffsetX -= 1;
            DrawOriginOffsetY -= 4;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Jamming:
                    if (++Projectile.frameCounter > 10)
                    {
                        Projectile.frame++;
                        Projectile.frameCounter = 0;

                        if (Projectile.frame < 11 || Projectile.frame > 14)
                            Projectile.frame = 11;
                    }
                    break;

                case States.Walking:
                    if (jumpCounter > 0)
                    {
                        if (++Projectile.frameCounter > 3 && Projectile.frame < 10)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame < 7)
                                Projectile.frame = 7;
                        }
                    }

                    if (Projectile.velocity.X != 0)
                    {
                        if (Projectile.velocity.Y == 0f)
                        {
                            if (++Projectile.frameCounter > 8)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;
                                if (Projectile.frame > 5)
                                    Projectile.frame = 0;
                            }
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    Projectile.frameCounter = 0;
                    Projectile.frame = 6;
                    break;
            }
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
                Main.EntitySpriteDraw(texture, position, rectangle, lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                return false;
            }
            if (CalValEX.month == 12 || Main.xMas)
            {
                Texture2D texture = ModContent.Request<Texture2D>(ChristmasTexture).Value;
                Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture.Width, texture.Height / Main.projFrames[Projectile.type]);
                Vector2 position = Projectile.Center - Main.screenPosition;
                position.X += DrawOffsetX;
                position.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture, position, rectangle, lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                return false;
            }
            return true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mClam = false;

            if (modPlayer.mClam)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            switch (state)
            {
                case States.Jamming:
                    if ((player.Center - Projectile.Center).LengthSquared() > BackToWalkingThreshold * BackToWalkingThreshold)
                    {
                        ResetMe(States.Walking);
                    }
                    break;

                case States.Walking:
                    if (Projectile.velocity.X == 0f && player.velocity.X == 0f)
                    {
                        if (Projectile.ai[0]++ > 240)
                        {
                            ResetMe(States.Jamming);
                        }
                    }
                    else
                    {
                        Projectile.ai[0] = 0;
                    }
                    break;
            }
        }
    }
}
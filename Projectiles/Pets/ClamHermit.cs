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
            DisplayName.SetDefault("Clam Hermit");
            Main.projFrames[projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 20;
            projectile.height = 26;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOffsetX -= 1;
            drawOriginOffsetY -= 4;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Jamming:
                    if (++projectile.frameCounter > 10)
                    {
                        projectile.frame++;
                        projectile.frameCounter = 0;

                        if (projectile.frame < 11 || projectile.frame > 14)
                            projectile.frame = 11;
                    }
                    break;

                case States.Walking:
                    if (jumpCounter > 0)
                    {
                        if (++projectile.frameCounter > 3 && projectile.frame < 10)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame < 7)
                                projectile.frame = 7;
                        }
                    }

                    if (projectile.velocity.X != 0)
                    {
                        if (projectile.velocity.Y == 0f)
                        {
                            if (++projectile.frameCounter > 8)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;
                                if (projectile.frame > 5)
                                    projectile.frame = 0;
                            }
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    projectile.frameCounter = 0;
                    projectile.frame = 6;
                    break;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (CalValEX.month == 10 || Main.halloween)
            {
                Texture2D texture = ModContent.GetTexture(HalloweenTexture);
                Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[projectile.type] * projectile.frame, texture.Width, texture.Height / Main.projFrames[projectile.type]);
                Vector2 position = projectile.Center - Main.screenPosition;
                position.X += drawOffsetX;
                position.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture, position, rectangle, lightColor, projectile.rotation, projectile.Size / 2f, 1f, (projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);
                return false;
            }
            if (CalValEX.month == 12 || Main.xMas)
            {
                Texture2D texture = ModContent.GetTexture(ChristmasTexture);
                Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[projectile.type] * projectile.frame, texture.Width, texture.Height / Main.projFrames[projectile.type]);
                Vector2 position = projectile.Center - Main.screenPosition;
                position.X += drawOffsetX;
                position.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture, position, rectangle, lightColor, projectile.rotation, projectile.Size / 2f, 1f, (projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);
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
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            switch (state)
            {
                case States.Jamming:
                    if ((player.Center - projectile.Center).LengthSquared() > BackToWalkingThreshold * BackToWalkingThreshold)
                    {
                        ResetMe(States.Walking);
                    }
                    break;

                case States.Walking:
                    if (projectile.velocity.X == 0f && player.velocity.X == 0f)
                    {
                        if (projectile.ai[0]++ > 240)
                        {
                            ResetMe(States.Jamming);
                        }
                    }
                    else
                    {
                        projectile.ai[0] = 0;
                    }
                    break;
            }
        }
    }
}
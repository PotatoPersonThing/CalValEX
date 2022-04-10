using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class BejeweledScuttler : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;

        public override float WalkingThreshold => 75f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Bejeweled Scuttler");
            Main.projFrames[projectile.type] = 10;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 62;
            projectile.height = 28;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -4f;
            twoTilesHigher = -6f;
            fiveTilesHigher = -8f;
            fourTilesHigher = -7f;
            anyOtherJump = -6.5f;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:

                    if (projectile.velocity.X != 0f)
                    {
                        if (projectile.velocity.Y == 0f)
                        {
                            if (++projectile.frameCounter > 8)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;
                                if (projectile.frame < 1 || projectile.frame > 3)
                                {
                                    projectile.frame = 1;
                                }
                            }
                        }
                        else
                        {
                            projectile.frameCounter = 0;

                            if (projectile.velocity.Y < -0.5f)
                                projectile.frame = 1;
                            else if (projectile.velocity.Y > 0.5f)
                                projectile.frame = 3;
                            else
                                projectile.frame = 2;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }

                    break;

                case States.Flying:

                    if (++projectile.frameCounter > 10)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < 4 || projectile.frame > 9)
                        {
                            projectile.frame = 4;
                        }
                    }

                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.rainbow = false;
            if (modPlayer.rainbow)
                projectile.timeLeft = 2;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/Scuttlers/BejeweledScuttlerGlow");
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int hei = frameHeight * projectile.frame;
            SpriteEffects rainbowy = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
            {
                rainbowy = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, hei, texture.Width, frameHeight)), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 109), projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, rainbowy, 0f);
        }
    }
}
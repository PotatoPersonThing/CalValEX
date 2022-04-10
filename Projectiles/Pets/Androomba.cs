using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class Androomba : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;

        public override float WalkingThreshold => 60f;

        public override bool FacesLeft => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Androomba");
            Main.projFrames[projectile.type] = 16;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 38;
            projectile.height = 36;
            projectile.ignoreWater = true;
            drawOriginOffsetY = 10;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -5.25f;
            twoTilesHigher = -6.5f;
            fiveTilesHigher = -9f;
            fourTilesHigher = -7.5f;
            anyOtherJump = -7f;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame > 3)
                                projectile.frame = 0;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    if (++projectile.frameCounter > 7)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame > 15 || projectile.frame < 4)
                            projectile.frame = 4;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.andro = false;

            if (modPlayer.andro)
                projectile.timeLeft = 2;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/Androomba_Glow");
            if (CalValEX.month == 12)
            {
                glowMask = mod.GetTexture("ExtraTextures/ChristmasPets/AndroombaGlow");
            }
            else
            {
                glowMask = mod.GetTexture("Projectiles/Pets/Androomba_Glow");
            }
            Rectangle frame = glowMask.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - projectile.width) * 0.5f + projectile.width * 0.5f + drawOriginOffsetX;
            spriteBatch.Draw
            (
                glowMask,
                projectile.position - Main.screenPosition + new Vector2(originOffsetX + drawOffsetX, projectile.height / 2 + projectile.gfxOffY),
                frame,
                Color.White,
                projectile.rotation,
                new Vector2(originOffsetX, projectile.height / 2 - drawOriginOffsetY),
                projectile.scale,
                projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
            );
        }
    }
}
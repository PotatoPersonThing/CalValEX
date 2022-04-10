using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace CalValEX.Projectiles.Pets
{
    public class PhantomPet : ModWalkingPet
    {
        public override bool FacesLeft => false;

        public override bool ShouldFlyRotate => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Phantom Larva");
            Main.projFrames[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 20;
            projectile.height = 14;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOffsetX = -7;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -4f;
            twoTilesHigher = -6f;
            fiveTilesHigher = -8f;
            fourTilesHigher = -7f;
            anyOtherJump = -6.5f;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            if (state == States.Flying)
            {
                if (projectile.spriteDirection == -1)
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + MathHelper.Pi;
                }
                else
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X);
                }
            }
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 7)
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
                        if (projectile.frame > 6 || projectile.frame < 4)
                            projectile.frame = 4;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mDebris = false;
            if (modPlayer.mDebris)
                projectile.timeLeft = 2;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/PhantomPet_Glow");
            if (CalValEX.month == 12)
            {
                glowMask = mod.GetTexture("ExtraTextures/ChristmasPets/PhantomPetGlow");
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
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace CalValEX.Projectiles.Pets
{
    public class AstPhage : ModWalkingPet
    {
        public override float TeleportThreshold => 1000f;

        public override float BackToWalkingThreshold => 200f;

        public override float BackToFlyingThreshold => 380f;

        public override float WalkingThreshold => 90f;

        public override bool ShouldFlyRotate => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Aureophage");
            Main.projFrames[projectile.type] = 18;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 46;
            projectile.height = 80;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 3)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame < 1 || projectile.frame > 11)
                                projectile.frame = 1;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    if (++projectile.frameCounter >= 5)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame < 12 || projectile.frame > 17)
                            projectile.frame = 12;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.AstPhage = false;

            if (modPlayer.AstPhage)
                projectile.timeLeft = 2;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -8f;
            twoTilesHigher = -9.5f;
            fiveTilesHigher = -14f;
            fourTilesHigher = -12.5f;
            anyOtherJump = -10.25f;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            if (state == States.Flying)
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + MathHelper.PiOver2;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/AstPhage_Glow");
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
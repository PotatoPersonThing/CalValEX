using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class MechaGeorge : ModWalkingPet
    {
        public override float WalkingSpeed => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Mecha George");
            Main.projFrames[projectile.type] = 11;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 48;
            projectile.height = 23;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOffsetX = -7;
            drawOriginOffsetY = -16;
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
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame < 1 || projectile.frame > 4)
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
                    if (++projectile.frameCounter > 10)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < 5 || projectile.frame > 10)
                            projectile.frame = 5;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.MechaGeorge = false;

            if (modPlayer.MechaGeorge)
                projectile.timeLeft = 2;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/MechaGeorge_Glow");
            if (CalValEX.month == 12)
            {
                glowMask = mod.GetTexture("ExtraTextures/ChristmasPets/MechaGeorgeGlow");
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
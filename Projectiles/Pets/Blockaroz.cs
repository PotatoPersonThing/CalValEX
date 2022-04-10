using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class Blockaroz : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;

        public override float WalkingThreshold => 80f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Bl0ckar0z");
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 34;
            projectile.height = 38;
            drawOriginOffsetY = CalValEX.month == 12 ? -10 : 2;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -5f;
            twoTilesHigher = -7f;
            fiveTilesHigher = -9f;
            fourTilesHigher = -8f;
            anyOtherJump = -7.5f;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    projectile.frame = 0;
                    break;

                case States.Flying:
                    projectile.frame = 1;
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Blok = false;

            if (modPlayer.Blok)
                projectile.timeLeft = 2;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/Blockaroz_Glow");
            if (CalValEX.month == 12)
            {
                glowMask = mod.GetTexture("ExtraTextures/ChristmasPets/BlockarozGlow");
            }
            else
            {
                glowMask = mod.GetTexture("Projectiles/Pets/Blockaroz_Glow");
            }
            Rectangle frame = glowMask.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - projectile.width) * 0.5f + projectile.width * 0.5f + drawOriginOffsetX;
            Mod ortho = ModLoader.GetMod("CalValPlus");
            if ((ortho != null) || (CalValEX.month == 4 && (CalValEX.day == 1 || CalValEX.day == 2 || CalValEX.day == 3 || CalValEX.day == 4 || CalValEX.day == 5 || CalValEX.day == 6 || CalValEX.day == 7)))
            {
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
}
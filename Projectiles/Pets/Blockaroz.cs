using Terraria;
using Microsoft.Xna.Framework.Graphics;
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
            // DisplayName.SetDefault("Bl0ckar0z");
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 34;
            Projectile.height = 38;
            DrawOriginOffsetY = CalValEX.month == 12 ? -10 : 2;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
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
                    Projectile.frame = 0;
                    break;

                case States.Flying:
                    Projectile.frame = 1;
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Blok = false;

            if (modPlayer.Blok)
                Projectile.timeLeft = 2;
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask;
            if (CalValEX.month == 12)
            {
                glowMask = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/ChristmasPets/BlockarozGlow").Value;
            }
            else
            {
                glowMask = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/Blockaroz_Glow").Value;
            }
            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            if (CalValEX.AprilFoolWeek)
            {
                Main.EntitySpriteDraw
                (
                    glowMask,
                    Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                    frame,
                    Color.White,
                    Projectile.rotation,
                    new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY),
                    Projectile.scale,
                    Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                    0
                );
            }
        }
    }
}
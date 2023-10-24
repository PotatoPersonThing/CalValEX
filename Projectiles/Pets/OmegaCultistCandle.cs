using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class OmegaCultistCandle : ModWalkingPet
    {
        public override float WalkingSpeed => 16f;

        public override bool FacesLeft => true;
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 548f;

        public override float WalkingThreshold => 75f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Province Pilferer");
            Main.projFrames[Projectile.type] = 13;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 50;
            Projectile.height = 48;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOriginOffsetY = 4;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -8f;
            twoTilesHigher = -10f;
            fiveTilesHigher = -16f;
            fourTilesHigher = -14f;
            anyOtherJump = -12.25f;
        }

        public override void Animation(int state)
        {
            switch (state)
            {
                case States.Walking:
                    if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 8)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame < 1 || Projectile.frame > 7)
                                Projectile.frame = 1;
                        }
                    }
                    else
                    {
                        if (++Projectile.frameCounter > 30)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame > 0)
                                Projectile.frame = 0;
                        }
                    }
                    break;

                case States.Flying:
                    if (Projectile.frame > 0)
                        Projectile.frame = 0;
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.oSquid = false;

            if (modPlayer.oSquid)
                Projectile.timeLeft = 2;
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/OmegaCultistGlow").Value;

            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
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

        public override void PreTeleport()
        {
            Gore.NewGore(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(0, -8), Mod.Find<ModGore>("OmegaCandle").Type, 1f);
        }
    }
}
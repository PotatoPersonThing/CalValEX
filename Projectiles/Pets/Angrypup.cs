using Terraria;
using System;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class Angrypup : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;
        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;
        public override float WalkingThreshold => 60f;

        public override bool ShouldFlyRotate => false;

        public override bool ShouldFlip
        {
            get
            {
                return state == States.Walking;
            }
        }

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Angry Pupper");
            Main.projFrames[Projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 82;
            Projectile.height = 44;
            Projectile.ignoreWater = true;
            DrawOriginOffsetY = 1;
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
            switch (state)
            {
                case States.Walking:
                    if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 8)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame > 5)
                                Projectile.frame = 0;
                        }
                    }
                    break;

                case States.Flying:
                    Projectile.frame = 6;
                    Projectile.frameCounter = 0;
                    Projectile.rotation += (MathHelper.TwoPi / 60f) * Projectile.direction * ((Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y)) * 0.2f);
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Angrypup = false;

            if (modPlayer.Angrypup)
                Projectile.timeLeft = 2;
        }
    }
}
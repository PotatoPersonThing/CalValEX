using Terraria;
using Microsoft.Xna.Framework;
using System;

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
            Main.projFrames[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 82;
            projectile.height = 44;
            projectile.ignoreWater = true;
            drawOriginOffsetY = 1;
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

                            if (projectile.frame > 5)
                                projectile.frame = 0;
                        }
                    }
                    break;

                case States.Flying:
                    projectile.frame = 6;
                    projectile.frameCounter = 0;
                    projectile.rotation += (MathHelper.TwoPi / 60f) * projectile.direction * ((Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.2f);
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Angrypup = false;

            if (modPlayer.Angrypup)
                projectile.timeLeft = 2;
        }
    }
}
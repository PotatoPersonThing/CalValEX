using Terraria;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class BabyCnidrion : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;

        public override float WalkingThreshold => 80f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Sneeze Dragon");
            Main.projFrames[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 38;
            projectile.height = 32;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
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
                        if (++projectile.frameCounter >= 8)
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
                    if (++projectile.frameCounter > 7)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < 5 || projectile.frame > 6)
                            projectile.frame = 5;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.BabyCnidrion = false;

            if (modPlayer.BabyCnidrion)
                projectile.timeLeft = 2;
        }
    }
}
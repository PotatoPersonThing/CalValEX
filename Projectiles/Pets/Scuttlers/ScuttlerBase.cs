using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public abstract class ScuttlerBase : ModWalkingPet
    {
        public abstract string ScuttlerName { get; }

        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;

        public override float WalkingThreshold => 40f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault(ScuttlerName + " Scuttler");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 16;
            projectile.height = 18;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOriginOffsetY = 2;
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
                    if (projectile.velocity.X != 0f)
                    {
                        if (projectile.velocity.Y == 0f)
                        {
                            SimpleAnimation(speed: 8);
                        }
                        else
                        {
                            projectile.frameCounter = 0;

                            if (projectile.velocity.Y < -0.5f)
                                projectile.frame = 1;
                            else if (projectile.velocity.Y > 0.5f)
                                projectile.frame = 3;
                            else
                                projectile.frame = 2;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    projectile.frame = 0;
                    break;
            }
        }
    }
}

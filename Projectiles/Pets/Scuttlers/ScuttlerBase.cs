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
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 16;
            Projectile.height = 18;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOriginOffsetY = 2;
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
                        if (Projectile.velocity.Y == 0f)
                        {
                            SimpleAnimation(speed: 8);
                        }
                        else
                        {
                            Projectile.frameCounter = 0;

                            if (Projectile.velocity.Y < -0.5f)
                                Projectile.frame = 1;
                            else if (Projectile.velocity.Y > 0.5f)
                                Projectile.frame = 3;
                            else
                                Projectile.frame = 2;
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    Projectile.frame = 0;
                    break;
            }
        }
    }
}

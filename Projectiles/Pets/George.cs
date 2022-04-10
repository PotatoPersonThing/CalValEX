using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class George : ModWalkingPet
    {
        public override bool FacesLeft => false;

        public override float TeleportThreshold => 2400f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("George");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 30;
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
                    if (projectile.velocity.Y != 0f)
                    {
                        if (projectile.velocity.Y > 0f)
                        {
                            projectile.frame = 3;
                            projectile.frameCounter = 0;
                        }
                        else
                        {
                            projectile.frame = 1;
                            projectile.frameCounter = 0;
                        }
                    }
                    else
                    {
                        if (projectile.velocity.X != 0f)
                        {
                            if (++projectile.frameCounter > 8)
                            {
                                projectile.frameCounter = 0;
                                projectile.frame++;
                                if (projectile.frame > 3)
                                    projectile.frame = 0;
                            }
                        }
                        else
                        {
                            projectile.frame = 0;
                            projectile.frameCounter = 0;
                        }
                    }
                    break;

                case States.Flying:
                    projectile.frameCounter = 0;
                    projectile.frame = 4;
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.George = false;

            if (modPlayer.George)
                projectile.timeLeft = 2;
        }
    }
}
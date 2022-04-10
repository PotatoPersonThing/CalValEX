using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class RedPanda : ModWalkingPet
    {
        public new class States
        {
            public const int Sleeping = -1;
            public const int Walking = 0;
            public const int Flying = 1;
        }

        public override bool FacesLeft => false;

        public override float WalkingSpeed => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Red Panda");
            Main.projFrames[projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 30;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOffsetX = -11;
            drawOriginOffsetY = -4;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -4f;
            twoTilesHigher = -6f;
            fiveTilesHigher = -8f;
            fourTilesHigher = -7f;
            anyOtherJump = -6.5f;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.rPanda = false;

            if (modPlayer.rPanda)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            if (state == States.Walking)
            {
                if (projectile.velocity.X == 0f && player.velocity.X == 0 && player.velocity.Y == 0 && (projectile.DistanceSQ(player.Center) < WalkingThreshold * WalkingThreshold))
                {
                    if (++projectile.ai[0] > 60 * 4)
                    {
                        ResetMe(States.Sleeping);
                    }
                }
                else
                {
                    projectile.ai[0] -= 2;
                    if (projectile.ai[0] < 0)
                        projectile.ai[0] = 0;
                }
            }

            if (state == States.Sleeping)
            {
                if ((projectile.Center - player.Center).Length() > WalkingThreshold * 4)
                {
                    if (++projectile.ai[0] > 60)
                    {
                        ResetMe(States.Walking);
                    }
                }
                else
                {
                    projectile.ai[0]--;
                    if (projectile.ai[0] < 0)
                        projectile.ai[0] = 0;
                }
            }
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Sleeping:
                    if (++projectile.frameCounter > 30)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame < 8 || projectile.frame > 11)
                            projectile.frame = 8;
                    }
                    break;

                case States.Walking:
                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 6)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame > 4)
                                projectile.frame = 0;
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

                        if (projectile.frame < 5 || projectile.frame > 7)
                            projectile.frame = 5;
                    }
                    break;
            }
        }
    }
}
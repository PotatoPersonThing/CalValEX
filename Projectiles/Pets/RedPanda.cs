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
            Main.projFrames[Projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 40;
            Projectile.height = 30;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOffsetX = -11;
            DrawOriginOffsetY = -4;
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
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            if (state == States.Walking)
            {
                if (Projectile.velocity.X == 0f && player.velocity.X == 0 && player.velocity.Y == 0 && (Projectile.DistanceSQ(player.Center) < WalkingThreshold * WalkingThreshold))
                {
                    if (++Projectile.ai[0] > 60 * 4)
                    {
                        ResetMe(States.Sleeping);
                    }
                }
                else
                {
                    Projectile.ai[0] -= 2;
                    if (Projectile.ai[0] < 0)
                        Projectile.ai[0] = 0;
                }
            }

            if (state == States.Sleeping)
            {
                if ((Projectile.Center - player.Center).Length() > WalkingThreshold * 4)
                {
                    if (++Projectile.ai[0] > 60)
                    {
                        ResetMe(States.Walking);
                    }
                }
                else
                {
                    Projectile.ai[0]--;
                    if (Projectile.ai[0] < 0)
                        Projectile.ai[0] = 0;
                }
            }
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Sleeping:
                    if (++Projectile.frameCounter > 30)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame < 8 || Projectile.frame > 11)
                            Projectile.frame = 8;
                    }
                    break;

                case States.Walking:
                    if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 6)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame > 4)
                                Projectile.frame = 0;
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    if (++Projectile.frameCounter > 10)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame < 5 || Projectile.frame > 7)
                            Projectile.frame = 5;
                    }
                    break;
            }
        }
    }
}
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
            // DisplayName.SetDefault("George");
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 40;
            Projectile.height = 30;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOffsetX = -7;
            DrawOriginOffsetY = -16;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
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
                    if (Projectile.velocity.Y != 0f)
                    {
                        if (Projectile.velocity.Y > 0f)
                        {
                            Projectile.frame = 3;
                            Projectile.frameCounter = 0;
                        }
                        else
                        {
                            Projectile.frame = 1;
                            Projectile.frameCounter = 0;
                        }
                    }
                    else
                    {
                        if (Projectile.velocity.X != 0f)
                        {
                            if (++Projectile.frameCounter > 8)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;
                                if (Projectile.frame > 3)
                                    Projectile.frame = 0;
                            }
                        }
                        else
                        {
                            Projectile.frame = 0;
                            Projectile.frameCounter = 0;
                        }
                    }
                    break;

                case States.Flying:
                    Projectile.frameCounter = 0;
                    Projectile.frame = 4;
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.George = false;

            if (modPlayer.George)
                Projectile.timeLeft = 2;
        }
    }
}
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class BuffReaper : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Buff lil man");
            Main.projFrames[projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 44;
            projectile.height = 36;
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
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame < 8 || projectile.frame > 14)
                                projectile.frame = 8;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 13;
                    }
                    break;

                case States.Flying:
                    if (++projectile.frameCounter > 10)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame > 7)
                            projectile.frame = 0;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.buffboi = false;

            if (modPlayer.buffboi)
                projectile.timeLeft = 2;
        }
    }
}
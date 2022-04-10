using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class RustyMimic : ModWalkingPet
    {
        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1200f;

        public override float WalkingSpeed => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Rusty Mimic");
            Main.projFrames[projectile.type] = 14;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 40;
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

                    if (projectile.velocity.Y != 0f)
                    {
                        if (++projectile.frameCounter > 5)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame < 1)
                                projectile.frame = 1;

                            if (projectile.frame > 3)
                                projectile.frame = 3;
                        }
                    }
                    else if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame < 1 || projectile.frame > 3)
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

                        if (projectile.frame < 4 || projectile.frame > 11)
                            projectile.frame = 4;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.rusty = false;

            if (modPlayer.rusty)
                projectile.timeLeft = 2;
        }
    }
}
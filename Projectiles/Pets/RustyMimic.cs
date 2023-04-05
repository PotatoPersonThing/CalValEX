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
            // DisplayName.SetDefault("Rusty Mimic");
            Main.projFrames[Projectile.type] = 14;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOriginOffsetY = 2;
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
            switch (state)
            {
                case States.Walking:

                    if (Projectile.velocity.Y != 0f)
                    {
                        if (++Projectile.frameCounter > 5)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame < 1)
                                Projectile.frame = 1;

                            if (Projectile.frame > 3)
                                Projectile.frame = 3;
                        }
                    }
                    else if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 8)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame < 1 || Projectile.frame > 3)
                                Projectile.frame = 1;
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    if (++Projectile.frameCounter > 7)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame < 4 || Projectile.frame > 11)
                            Projectile.frame = 4;
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
                Projectile.timeLeft = 2;
        }
    }
}
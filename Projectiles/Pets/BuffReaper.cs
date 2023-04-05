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
            // DisplayName.SetDefault("Buff lil man");
            Main.projFrames[Projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 44;
            Projectile.height = 36;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOriginOffsetY = 1;
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
                    if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 8)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame < 8 || Projectile.frame > 14)
                                Projectile.frame = 8;
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 13;
                    }
                    break;

                case States.Flying:
                    if (++Projectile.frameCounter > 10)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame > 7)
                            Projectile.frame = 0;
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
                Projectile.timeLeft = 2;
        }
    }
}
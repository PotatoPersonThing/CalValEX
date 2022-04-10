using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumOrb : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 548f;

        public override float WalkingThreshold => 75f;

        public override float WalkingSpeed => 17f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Wulfrom Gyrothing");
            Main.projFrames[projectile.type] = 10;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 24;
            projectile.height = 24;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
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
            Player player = Main.player[projectile.owner];
            int frameOffset = 0;
            int animationSpeed = state == States.Flying ? 10 : 8;
            if (player.HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                frameOffset = 5;
                animationSpeed /= 2;
            }

            if (++projectile.frameCounter > animationSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame > frameOffset + 4 || projectile.frame < frameOffset)
                {
                    projectile.frame = frameOffset;
                }
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.worb = false;

            if (modPlayer.worb)
                projectile.timeLeft = 2;
        }
    }
}
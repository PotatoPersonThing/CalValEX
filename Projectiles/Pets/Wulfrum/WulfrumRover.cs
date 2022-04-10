using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumRover : ModWalkingPet
    {
        public override float FlyingSpeed => 14f;

        public override float WalkingDrag => 14f;

        public override bool FacesLeft => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Wulfrom Rover");
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 20;
            projectile.height = 26;
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
            Player player = Main.player[projectile.owner];
            int frameOffset = 0;
            int animationSpeed = state == States.Flying ? 10 : 8;
            if (player.HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                frameOffset = 4;
                animationSpeed /= 2;
            }

            if (++projectile.frameCounter > animationSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame > frameOffset + 3 || projectile.frame < frameOffset)
                {
                    projectile.frame = frameOffset;
                }
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.rover = false;
            if (modPlayer.rover)
                projectile.timeLeft = 2;
        }
    }
}
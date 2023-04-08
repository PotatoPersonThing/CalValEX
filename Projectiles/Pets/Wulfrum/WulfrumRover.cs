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
            // DisplayName.SetDefault("Wulfrom Rover");
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 20;
            Projectile.height = 26;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOriginOffsetY = 2;
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
            Player player = Main.player[Projectile.owner];
            int frameOffset = 0;
            int animationSpeed = state == States.Flying ? 10 : 8;
            if (player.HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                frameOffset = 4;
                animationSpeed /= 2;
            }

            if (++Projectile.frameCounter > animationSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame > frameOffset + 3 || Projectile.frame < frameOffset)
                {
                    Projectile.frame = frameOffset;
                }
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.rover = false;
            if (modPlayer.rover)
                Projectile.timeLeft = 2;
        }
    }
}
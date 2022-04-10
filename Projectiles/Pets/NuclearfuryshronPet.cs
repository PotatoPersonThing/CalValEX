using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class NuclearfuryshronPet : ModFlyingPet
    {
        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Dukapitated Pet");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 22;
            projectile.height = 22;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mDuke = false;

            if (modPlayer.mDuke)
                projectile.timeLeft = 2;
        }
    }
}
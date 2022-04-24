using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class NuclearfuryshronPet : ModFlyingPet
    {
        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Dukapitated Pet");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
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
                Projectile.timeLeft = 2;
        }
    }
}
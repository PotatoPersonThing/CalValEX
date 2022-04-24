using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class OmegaSquid : ModFlyingPet
    {
        public override bool FacesLeft => false;

        public override bool ShouldFlip => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Omega Squid");
            Main.projFrames[Projectile.type] = 6;
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
                modPlayer.oSquid = false;

            if (modPlayer.oSquid)
                Projectile.timeLeft = 2;
        }
    }
}
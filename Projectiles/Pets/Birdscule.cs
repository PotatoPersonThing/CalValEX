using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Birdscule : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override bool FacesLeft => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 78;
            Projectile.height = 92;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.ogscule = false;

            if (modPlayer.ogscule)
                Projectile.timeLeft = 2;
        }
    }
}
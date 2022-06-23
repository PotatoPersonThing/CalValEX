using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class StasisArmored : ModFlyingPet
    {
        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Stasis Drone");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
        }

        public override float TeleportThreshold => 1440f;

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mArmored = false;

            if (modPlayer.mArmored)
                Projectile.timeLeft = 2;
        }
    }
}
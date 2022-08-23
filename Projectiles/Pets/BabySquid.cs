using Terraria;

namespace CalValEX.Projectiles.Pets {
    public class BabySquid : ModFlyingPet {
        public override float TeleportThreshold => 1440f;

        public override void SetStaticDefaults() {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Lil' Squid");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults() {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void Animation(int state) => SimpleAnimation(speed: 8);

        public override void PetFunctionality(Player player) {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.squid = false;

            if (modPlayer.squid)
                Projectile.timeLeft = 2;
        }
    }
}
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class MiniCryoCalless : ModFlyingPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/MiniCryo";

        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1840f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Chill Dude");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 20;
            Projectile.height = 24;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SimpleAura(Main.spriteBatch, new string[] { "CalValEX/Projectiles/Pets/MiniCryoShield" }, false);
            return base.PreDraw(ref lightColor);
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.MiniCryo = false;

            if (modPlayer.MiniCryo)
                Projectile.timeLeft = 2;
        }
    }
}
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class SolarBunny : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Solar Bunny");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 34;
            Projectile.height = 28;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SimpleAura(Main.spriteBatch, true);
            return base.PreDraw(ref lightColor);
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            auraRotation += MathHelper.TwoPi / 120;
            AddLight(new Color(255, 191, 73), 1.75f, 6);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.sBun = false;

            if (modPlayer.sBun)
                Projectile.timeLeft = 2;
        }
    }
}
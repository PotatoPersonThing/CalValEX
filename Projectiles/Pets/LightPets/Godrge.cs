using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class Godrge : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Nuclear George");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 46;
            Projectile.height = 42;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SimpleAura(Main.spriteBatch, true);
            return true;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(255, 191, 73), 2f, 6);
            auraRotation += MathHelper.TwoPi / 120;
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.GeorgeII = false;

            if (modPlayer.GeorgeII)
                Projectile.timeLeft = 2;
        }
    }
}
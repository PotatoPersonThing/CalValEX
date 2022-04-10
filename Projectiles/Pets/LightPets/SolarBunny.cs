using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class SolarBunny : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Solar Bunny");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 34;
            projectile.height = 28;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleAura(spriteBatch, true);
            return base.PreDraw(spriteBatch, lightColor);
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
                projectile.timeLeft = 2;
        }
    }
}
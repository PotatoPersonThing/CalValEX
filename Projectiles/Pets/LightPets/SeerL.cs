using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class SeerL : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override Vector2 FlyingOffset => new Vector2(21f * Main.player[projectile.owner].direction, -11f);

        public override float FlyingSpeed => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Small Sightseer");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 62;
            projectile.height = 30;
            projectile.ignoreWater = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            string glowmaskTexture = CalValEX.month == 12 ? "CalValEX/ExtraTextures/ChristmasPets/SeerLGlow" : "CalValEX/Projectiles/Pets/LightPets/SeerL_Glow";
            SimpleGlowmask(spriteBatch, glowmaskTexture);
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(255, 71, 66), 0.9f, 2);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 4);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.seerL = false;

            if (modPlayer.seerL)
                projectile.timeLeft = 2;
        }
    }
}
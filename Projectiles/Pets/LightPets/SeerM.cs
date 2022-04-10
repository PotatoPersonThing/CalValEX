using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class SeerM : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override Vector2 FlyingOffset => new Vector2(23f * Main.player[projectile.owner].direction, -21f);

        public override float FlyingSpeed => 20f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Mini Sightseer");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 42;
            projectile.height = 18;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 4);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            string glowmaskTexture = CalValEX.month == 12 ? "CalValEX/ExtraTextures/ChristmasPets/SeerMGlow" : "CalValEX/Projectiles/Pets/LightPets/SeerM_Glow";
            SimpleGlowmask(spriteBatch, glowmaskTexture);
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(0, 251, 199), 0.75f, 0);
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
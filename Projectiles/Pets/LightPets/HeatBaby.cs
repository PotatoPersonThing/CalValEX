using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class HeatBaby : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override Vector2 FlyingOffset => new Vector2(35f * Main.player[Projectile.owner].direction, -41f);

        public override float FlyingSpeed => 20f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Baby Cinder Spirit");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 24;
            Projectile.height = 21;
            Projectile.ignoreWater = true;
        }

        public override void PostDraw(Color lightColor)
        {
            string glowmaskTexture = CalValEX.month == 12 ? "CalValEX/ExtraTextures/ChristmasPets/HeatBabyGlow" : "CalValEX/Projectiles/Pets/LightPets/HeatBaby_Glow";
            SimpleGlowmask(Main.spriteBatch, glowmaskTexture);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 4);
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(253, 19, 43), 0.3f, 0);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mHeat = false;

            if (modPlayer.mHeat)
                Projectile.timeLeft = 2;
        }
    }
}
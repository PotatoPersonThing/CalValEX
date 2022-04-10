using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class HeatPet : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override Vector2 FlyingOffset => new Vector2(11f * Main.player[projectile.owner].direction, -21f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Cinder Spirit");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 24;
            projectile.ignoreWater = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 4);
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(253, 19, 43), 0.7f, 2);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mHeat = false;

            if (modPlayer.mHeat)
                projectile.timeLeft = 2;
        }
    }
}
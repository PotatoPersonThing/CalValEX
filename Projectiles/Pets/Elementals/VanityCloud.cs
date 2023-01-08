using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityCloud : ModFlyingPet
    {
        public override float TeleportThreshold => 1200f;

        public override bool ShouldFlyRotate => false;

        public override Vector2 FlyingOffset => new Vector2(408f, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Cloud");
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 58;
            Projectile.height = 116;
            Projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                Projectile.timeLeft = 0;

            if (!modPlayer.vanityhote && !modPlayer.vanitycloud)
                Projectile.timeLeft = 0;

            if (modPlayer.vanityhote || modPlayer.vanitycloud)
                Projectile.timeLeft = 2;

            Projectile.rotation = 0;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 16);
        }
    }
}
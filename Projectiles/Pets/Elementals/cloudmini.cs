using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class CloudMini : ModFlyingPet
    {
        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(-204f * -Main.player[Projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Cloudy");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.cloudmini = false;

            if (modPlayer.cloudmini)
                Projectile.timeLeft = 2;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 7);
        }
    }
}
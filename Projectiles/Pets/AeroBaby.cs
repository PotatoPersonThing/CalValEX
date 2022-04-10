using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class AeroBaby : ModFlyingPet
    {
        public override Vector2 FlyingOffset => new Vector2(38f * -Main.player[projectile.owner].direction, -70f);

        public override float TeleportThreshold => 1440f;

        public override float FlyingSpeed => 16f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Aero Baby");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 22;
            projectile.height = 22;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mAero = false;

            if (modPlayer.mAero)
                projectile.timeLeft = 2;
        }
    }
}
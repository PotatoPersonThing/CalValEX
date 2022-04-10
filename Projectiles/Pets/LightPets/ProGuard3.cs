using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class ProGuard3 : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(78f * -Main.player[projectile.owner].direction, -120f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Angry Small Potato");
            Main.projFrames[projectile.type] = 1;
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
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.ProGuard3 = false;

            if (modPlayer.ProGuard3)
                projectile.timeLeft = 2;
        }
    }
}
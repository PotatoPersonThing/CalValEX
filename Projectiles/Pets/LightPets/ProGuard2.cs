using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class ProGuard2 : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(148f * -Main.player[Projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Nice Small Potato");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.ProGuard2 = false;

            if (modPlayer.ProGuard2)
                Projectile.timeLeft = 2;
        }
    }
}
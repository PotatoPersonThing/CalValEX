using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class ProGuard3 : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(78f * -Main.player[Projectile.owner].direction, -120f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Angry Small Potato");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 46;
            Projectile.height = 36;
            Projectile.ignoreWater = true;
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 4);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.ProGuard3 = false;

            if (modPlayer.ProGuard3)
                Projectile.timeLeft = 2;
        }
    }
}
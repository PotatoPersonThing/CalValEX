using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class Skeetyeet : ModFlyingPet
    {
        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(1.5f * Main.player[Projectile.owner].direction, -7f);

        public override float FlyingSpeed => 50f;

        public override float FlyingInertia => 120f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Sunfish");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 34;
            Projectile.height = 16;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void Animation(int state)
        {
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(250, 155, 97), 0.6f, 6);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Skeetyeet = false;

            if (modPlayer.Skeetyeet)
                Projectile.timeLeft = 2;
        }
    }
}
using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class CoolBlueSlime : ModFlyingPet
    {
        public override float TeleportThreshold => 1840f;

        public override Vector2 FlyingOffset => new Vector2(56f * -Main.player[Projectile.owner].direction, -50f);

        public override bool ShouldFlip => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Cool Blue Slime God");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.bSlime = false;

            if (modPlayer.bSlime)
                Projectile.timeLeft = 2;
        }
    }
}
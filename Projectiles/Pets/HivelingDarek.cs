using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class HivelingDarek : ModFlyingPet
    {
        public override bool ShouldFlip => false;

        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new(88f * Main.player[Projectile.owner].direction, -20f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
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
                modPlayer.mHive = false;

            if (modPlayer.mHive)
                Projectile.timeLeft = 2;
        }
    }
}
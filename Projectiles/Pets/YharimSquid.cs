using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class YharimSquid : ModFlyingPet
    {
        public override bool FacesLeft => false;

        public override bool ShouldFlip => false;

        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[Projectile.owner].direction, -70f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Yharim Squid");
            Main.projFrames[Projectile.type] = 8;
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
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.ySquid = false;

            if (modPlayer.ySquid)
                Projectile.timeLeft = 2;
        }
    }
}
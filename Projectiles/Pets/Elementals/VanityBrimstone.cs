using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityBrimstone : ModFlyingPet
    {
        public override string Texture => "CalamityMod/Projectiles/Summon/BrimstoneElementalMinion";

        public override float TeleportThreshold => 1200f;

        public override bool ShouldFlyRotate => false;

        public override Vector2 FlyingOffset => new Vector2(-408f, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Brimstone");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 78;
            projectile.height = 126;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 16);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                projectile.timeLeft = 0;

            if (!modPlayer.vanityhote && !modPlayer.vanitybrim)
                projectile.timeLeft = 0;

            if (modPlayer.vanityhote || modPlayer.vanitybrim)
                projectile.timeLeft = 2;

            projectile.rotation = 0;
        }
    }
}
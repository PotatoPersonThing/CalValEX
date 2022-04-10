using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanitySand : ModFlyingPet
    {
        public override string Texture => "CalamityMod/Projectiles/Summon/SandElementalMinion";

        public override float TeleportThreshold => 1200f;

        public override bool ShouldFlyRotate => false;

        public override Vector2 FlyingOffset => new Vector2(180f, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Sand");
            Main.projFrames[projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 42;
            projectile.height = 98;
            projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                projectile.timeLeft = 0;

            if (!modPlayer.vanityhote && !modPlayer.vanitysand)
                projectile.timeLeft = 0;

            if (modPlayer.vanityhote || modPlayer.vanitysand)
                projectile.timeLeft = 2;

            projectile.rotation = 0;
        }

        public override void Animation(int state)
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 5)
                projectile.frame = 0;
        }
    }
}
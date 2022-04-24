using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanitySand : ModFlyingPet
    {
        //public override string Texture => "CalamityMod/Projectiles/Summon/SandElementalMinion";
        public override string Texture => "CalValEx/Projectiles/Pets/Elementals/Sandmini";

        public override float TeleportThreshold => 1200f;

        public override bool ShouldFlyRotate => false;

        public override Vector2 FlyingOffset => new Vector2(180f, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Sand");
            Main.projFrames[Projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 42;
            Projectile.height = 98;
            Projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                Projectile.timeLeft = 0;

            if (!modPlayer.vanityhote && !modPlayer.vanitysand)
                Projectile.timeLeft = 0;

            if (modPlayer.vanityhote || modPlayer.vanitysand)
                Projectile.timeLeft = 2;

            Projectile.rotation = 0;
        }

        public override void Animation(int state)
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 6)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 5)
                Projectile.frame = 0;
        }
    }
}
using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityYoungDuke : ModFlyingPet
    {
        public override string Texture => "CalamityMod/Projectiles/Summon/YoungDuke";

        public override bool ShouldFlyRotate => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Young Duke");
            Main.projFrames[projectile.type] = 16;
        }

        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(108f * -Main.player[projectile.owner].direction, -50f);

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 30;
            projectile.height = 30;
            projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                projectile.timeLeft = 0;
            if (!modPlayer.vanityyound)
                projectile.timeLeft = 0;
            if (modPlayer.vanityyound)
                projectile.timeLeft = 2;
        }

        public override void Animation(int state)
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 6)
                projectile.frame = 0;
            projectile.rotation = 0;
        }
    }
}
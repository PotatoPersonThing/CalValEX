using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityCloud : ModFlyingPet
    {
        public override string Texture => "CalamityMod/NPCs/NormalNPCs/ThiccWaifu";

        public override float TeleportThreshold => 1200f;

        public override bool ShouldFlyRotate => false;

        public override Vector2 FlyingOffset => new Vector2(408f, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Cloud");
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 58;
            projectile.height = 116;
            projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                projectile.timeLeft = 0;

            if (!modPlayer.vanityhote && !modPlayer.vanitycloud)
                projectile.timeLeft = 0;

            if (modPlayer.vanityhote || modPlayer.vanitycloud)
                projectile.timeLeft = 2;

            projectile.rotation = 0;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 16);
        }
    }
}
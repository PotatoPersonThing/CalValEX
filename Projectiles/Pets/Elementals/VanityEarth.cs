using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityEarth : ModFlyingPet
    {
        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(-110f, -250f);

        public override bool ShouldFlyRotate => false;

        public override string Texture => "CalamityMod/NPCs/NormalNPCs/Horse";

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Earth Elemental");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 230;
            Projectile.height = 230;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 16);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                Projectile.timeLeft = 0;

            if (!modPlayer.vanityhote && !modPlayer.vanityearth)
                Projectile.timeLeft = 0;

            if (modPlayer.vanityhote || modPlayer.vanityearth)
                Projectile.timeLeft = 2;

            Projectile.rotation = 0;
        }
    }
}
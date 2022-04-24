using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityRareSand : ModFlyingPet
    {
        //public override string Texture => "CalamityMod/Projectiles/Summon/SandElementalHealer";
        public override string Texture => "CalValEx/Projectiles/Pets/Elementals/RaresandMini";

        public override float TeleportThreshold => 1200f;

        public override bool ShouldFlyRotate => false;

        public override Vector2 FlyingOffset => new Vector2(-180f, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Rare Sand");
            Main.projFrames[Projectile.type] = 6;
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

            if (!modPlayer.vanityhote && !modPlayer.vanityrare)
                Projectile.timeLeft = 0;

            if (modPlayer.vanityhote || modPlayer.vanityrare)
                Projectile.timeLeft = 2;

            Projectile.rotation = 0;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 16);
        }
    }
}
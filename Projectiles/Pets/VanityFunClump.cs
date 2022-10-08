using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityFunClump : ModFlyingPet
    {
        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[Projectile.owner].direction, -50f);

        public override string Texture => "CalamityMod/Projectiles/Typeless/FungalClumpMinion";

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Fungal Clump");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 40;
            Projectile.height = 40;
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
                Projectile.timeLeft = 0;

            if (!modPlayer.vanityfunclump)
                Projectile.timeLeft = 0;

            if (modPlayer.vanityfunclump)
                Projectile.timeLeft = 2;
        }
    }
}
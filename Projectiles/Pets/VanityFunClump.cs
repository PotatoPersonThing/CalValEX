using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityFunClump : ModFlyingPet
    {
        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[projectile.owner].direction, -50f);

        public override string Texture => "CalamityMod/Projectiles/Summon/FungalClumpMinion";

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Passive Fungal Clump");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 40;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                projectile.timeLeft = 0;

            if (!modPlayer.vanityfunclump)
                projectile.timeLeft = 0;

            if (modPlayer.vanityfunclump)
                projectile.timeLeft = 2;
        }
    }
}
using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class RareBrimling : ModFlyingPet
    {
        public override float TeleportThreshold => 1200f;

        public override Vector2 FlyingOffset => new Vector2(204f * -Main.player[projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Rare Brimling");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 22;
            projectile.height = 22;
            projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.rarebrimling = false;

            if (modPlayer.rarebrimling)
                projectile.timeLeft = 2;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 7);
        }
    }
}
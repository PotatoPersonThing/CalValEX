using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class FogPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fogbound");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(197);
            base.aiType = 197;
        }

        public override bool PreAI()
        {
            _ = Main.player[projectile.owner];
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.fog = false;
            }
            if (modPlayer.fog)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}
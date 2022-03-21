using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class TUB : ModProjectile
    {
        public Player Owner => Main.player[projectile.owner];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TUB");
            Main.projFrames[projectile.type] = 11;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(334);
            base.aiType = 334;
            base.drawOriginOffsetY = -14;
            base.drawOffsetX = -10;
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
                modPlayer.tub = false;
            }
            if (modPlayer.tub)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class WraithsExcalibur : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wraith's Excalibur");
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(197);
            base.AIType = 197;
            base.DrawOriginOffsetY = -33;
        }

        public override bool PreAI()
        {
            _ = Main.player[Projectile.owner];
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.excal = false;
            }
            if (modPlayer.excal)
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}
using CalValEX.Items;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles
{
    public class CalaFumoSpeen : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 8;
        }
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 44;
            projectile.height = 44;
            projectile.aiStyle = 32;
            projectile.friendly = true;
        }

        public override void Kill(int timeLeft)
        {
            Item.NewItem(projectile.getRect(), ModContent.ItemType<CalaFumoYeetable>());
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 6)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= Main.projFrames[projectile.type])
                    projectile.frame = 0;
            }
        }
    }
}
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items;

namespace CalValEX.Projectiles
{
    public class CalaFumo : ModProjectile
    {
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
            Item.NewItem(projectile.getRect(), ModContent.ItemType<CalamitasFumo>());
        }
    }
}

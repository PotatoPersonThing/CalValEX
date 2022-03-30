using CalValEX.Items.Plushies;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Plushies
{
    public class CalaFumo : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.aiStyle = 32;
            Projectile.friendly = true;
        }

        public override void Kill(int timeLeft)
        {
            Item.NewItem(Projectile.GetItemSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<CalaFumoYeetable>());
        }
    }
}
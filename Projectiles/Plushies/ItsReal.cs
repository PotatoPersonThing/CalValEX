using CalValEX.Items.Plushies;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Plushies
{
    public class ItsReal : ModProjectile
    {
        bool invincibility = false;
        int counter;
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 84;
            projectile.height = 154;
            projectile.aiStyle = 32;
            projectile.friendly = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            counter++;
            if (counter == 60)
            {
                projectile.tileCollide = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            Item.NewItem(projectile.getRect(), ModContent.ItemType<CalaFumoYeetable>());
        }
    }
}
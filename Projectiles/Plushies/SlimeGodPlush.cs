using CalValEX.Items.Plushies;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Plushies
{
    public class SlimeGodPlush : ModProjectile
    {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/SlimeGodPlush";
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
            Item.NewItem(projectile.getRect(), ModContent.ItemType<Items.Plushies.SlimeGodPlushThrowable>());
        }
    }
}
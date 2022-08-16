using CalValEX.Items.Plushies;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Plushies {
    public class MirePlushP1 : ModProjectile {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/MirePlushP1";
        public override void SetDefaults() {
            Projectile.netImportant = true;
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.aiStyle = 32;
            Projectile.friendly = true;
        }

        public override void Kill(int timeLeft) {
            Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<MirePlushThrowableP1>());
        }
    }

    public class MirePlushP2 : ModProjectile {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/MirePlushP2";
        public override void SetDefaults() {
            Projectile.netImportant = true;
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.aiStyle = 32;
            Projectile.friendly = true;
        }

        public override void Kill(int timeLeft) {
            Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<MirePlushThrowableP2>());
        }
    }
}
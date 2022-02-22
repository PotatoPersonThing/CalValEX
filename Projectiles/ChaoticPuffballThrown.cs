using CalValEX.Items;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles
{
    public class ChaoticPuffballThrown : ModProjectile
    {
        public override string Texture => "CalValEX/Items/ChaoticPuffball";
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
            Item.NewItem(projectile.getRect(), ModContent.ItemType<ChaoticPuffball>());
            if (Main.rand.Next(10) == 0)
            {
                Main.PlaySound(Terraria.ID.SoundID.Item20, projectile.position);
                Projectile.NewProjectile(projectile.position, new Microsoft.Xna.Framework.Vector2 (0, 0), Terraria.ID.ProjectileID.InfernoHostileBlast, 222, 10, Main.myPlayer);
            }
        }
    }
}
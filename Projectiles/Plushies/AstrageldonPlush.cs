﻿using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Plushies
{
    public class AstrageldonPlush : ModProjectile
    {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/AstrageldonPlush";
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.aiStyle = 32;
            Projectile.friendly = true;
        }

        public override void OnKill(int timeLeft)
        {
            Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<Items.Plushies.AstrageldonPlushThrowable>());
        }
    }
}
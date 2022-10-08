using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    public class ProfanedEnergyHook : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults()
        {
            Item.rare = 11;
            Item.CloneDefaults(ItemID.BatHook);
            Item.value = Item.sellPrice(1, 1, 0, 0);
            Item.shootSpeed = 16f;
            Item.shoot = ProjectileType<ProfanedHook>();
        }
    }
}
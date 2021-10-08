using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    internal class ProfanedEnergyHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Profaned Energy Hook");
            Tooltip.SetDefault("Rattle the holy chains\nReach: 37\nLaunch Velocity: 16\nPull Velocity: 30");
        }

        public override void SetDefaults()
        {
            item.rare = 11;
            item.CloneDefaults(ItemID.BatHook);
            item.value = Item.sellPrice(1, 1, 0, 0);
            item.shootSpeed = 16f;
            item.shoot = ProjectileType<ProfanedHook>();
        }
    }
}
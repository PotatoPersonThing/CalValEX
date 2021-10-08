using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    internal class ScavaHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Scavenger Claw");
            Tooltip.SetDefault("Here to gouge out your eyes, runic style!\nReach: 50\nLaunch Velocity: 19\nPull Velocity: 25");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BatHook);
            item.shootSpeed = 19f;
            item.shoot = ProjectileType<ScavaClaw>();
            item.rare = 9;
        }
    }
}
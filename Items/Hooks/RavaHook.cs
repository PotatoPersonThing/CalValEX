using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    internal class RavaHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ravager Claw");
            Tooltip.SetDefault("Here to gouge out your eyes\nReach: 43\nLaunch Velocity: 18\nPull Velocity: 20");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BatHook);
            item.shootSpeed = 18f;
            item.shoot = ProjectileType<RavaClaw>();
            item.rare = 8;
        }
    }
}
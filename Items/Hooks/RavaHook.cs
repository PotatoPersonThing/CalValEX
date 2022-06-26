using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    public class RavaHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ravager Claw");
            Tooltip.SetDefault("Here to gouge out your eyes\nReach: 43\nLaunch Velocity: 18\nPull Velocity: 20");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BatHook);
            Item.shootSpeed = 18f;
            Item.shoot = ProjectileType<RavaClaw>();
            Item.rare = 8;
        }
    }
}
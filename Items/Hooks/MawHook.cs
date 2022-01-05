using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    public class MawHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cragmaw Spinehook");
            Tooltip.SetDefault("Prehistoric pull power!\nReach: 31\nLaunch Velocity: 18\nPull Velocity: 17");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BatHook);
            item.shootSpeed = 18f;
            item.shoot = ProjectileType<MawTeeth>();
            item.rare = 5;
        }
    }
}
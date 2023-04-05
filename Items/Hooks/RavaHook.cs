using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    public class RavaHook : ModItem {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BatHook);
            Item.shootSpeed = 18f;
            Item.shoot = ProjectileType<RavaClaw>();
            Item.rare = 8;
        }
    }
}
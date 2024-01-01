using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class InactivePowerFactory : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Inactive Power Cell Factory");
            // Tooltip.SetDefault("An unpowered Power Cell Factory\n" + "Break to reactivate");
            Item.ResearchUnlockCount = 1;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void SetDefaults()
        {
            Item.maxStack = 99;
            Item.width = 16;
            Item.height = 28;
            Item.rare = -1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }
    }
}

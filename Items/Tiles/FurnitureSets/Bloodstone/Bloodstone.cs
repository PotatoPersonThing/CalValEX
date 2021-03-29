using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
    public class Bloodstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Compensation");
            Tooltip.SetDefault("Can be sold");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = -1;
        }
    }
}
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class PristineExcalibur : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Compensation");
            Tooltip
                .SetDefault("Can be sold for a decent price");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = -1;
        }
    }
}
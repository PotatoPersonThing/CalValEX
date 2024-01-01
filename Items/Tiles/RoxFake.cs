using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class RoxFake : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Placeable Roxcalibur");
            /* Tooltip
                .SetDefault("'You can rock!'"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 99;
            Item.width = 44;
            Item.height = 64;
            Item.rare = -1;
            Item.value = Item.buyPrice(0, 1, 0, 0);
        }
    }
}
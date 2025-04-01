using Terraria.ModLoader;
using Terraria;

namespace CalValEX.Items.Tiles
{
    public class SulphurColumn : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sulphurous Column");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.width = 16;
            Item.height = 28;
            Item.rare = -1;
            Item.value = Item.sellPrice(0, 0, 10, 0);
        }
    }
}
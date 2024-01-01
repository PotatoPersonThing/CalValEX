using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class Ribrod : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ribcage Wand");
            // Tooltip.SetDefault("Places Sulphurous Ribs\n" + "Right click to change rib");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 1;
            Item.width = 16;
            Item.height = 28;
            Item.rare = -1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }
    }
}
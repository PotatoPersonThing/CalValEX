using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class NuclearFumes : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nuclear Fumes");
            // Tooltip.SetDefault("Don't inhale them");
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.maxStack = 9999;
            Item.rare = CalamityID.CalRarityID.PureGreen;
        }
    }
}
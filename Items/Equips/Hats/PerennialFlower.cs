using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Face)]
    public class PerennialFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perennial Tulip");
            Tooltip.SetDefault("Am I a pretty girl?");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 6;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
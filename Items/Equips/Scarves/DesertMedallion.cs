using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Scarves
{
    [AutoloadEquip(EquipType.Neck)]
    public class DesertMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Budget Desert Medallion");
            Tooltip.SetDefault("Because the other one is too cursed to wear");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 2;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
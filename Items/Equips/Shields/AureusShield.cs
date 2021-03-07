using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shields
{
    [AutoloadEquip(EquipType.Shield)]
    public class AureusShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aureus Plating");
            Tooltip.SetDefault("Smaller in execution");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 7;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
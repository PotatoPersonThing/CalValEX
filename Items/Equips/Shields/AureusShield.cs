using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shields
{
    [AutoloadEquip(EquipType.Shield)]
    public class AureusShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aureus Bulwark");
            Tooltip.SetDefault("Smaller in execution");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
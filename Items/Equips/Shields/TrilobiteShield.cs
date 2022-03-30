using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shields
{
    [AutoloadEquip(EquipType.Shield)]
    public class TrilobiteShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trilobuckler");
            Tooltip.SetDefault("An ancient shield that's too old to block attacks");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
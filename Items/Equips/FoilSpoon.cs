using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Balloon)]
    public class FoilSpoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Foil Spoon");
            Tooltip.SetDefault("'spoon'");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 38;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
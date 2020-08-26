using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Balloon)]
    public class FoilAtlantis : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Foil Atlantis");
            Tooltip.SetDefault("'A miniature, inflatable replica of the magical halberd'");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 40;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
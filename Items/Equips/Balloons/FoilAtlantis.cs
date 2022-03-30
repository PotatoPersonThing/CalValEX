using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
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
            Item.width = 42;
            Item.height = 40;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class FoilSpoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Foil Spoon");
            Tooltip.SetDefault("'spoon'");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
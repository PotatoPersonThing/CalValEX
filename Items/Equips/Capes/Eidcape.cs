using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Capes
{
    [AutoloadEquip(EquipType.Front)]
    public class Eidcape : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eidolist Cape");
            Tooltip.SetDefault("Whispers of the deep can be heard through the weavings of this eldritch fabric...");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
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
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
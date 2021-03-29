using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Scarves
{
    [AutoloadEquip(EquipType.Neck)]
    public class AstBandana : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Bandana");
            Tooltip.SetDefault("Space Age Fashion!");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 32;
            item.value = Item.sellPrice(0, 1, 10, 0);
            item.rare = 6;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
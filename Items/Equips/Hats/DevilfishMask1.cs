using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class DevilfishMask1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Curly Devil Fish Mask");
            Tooltip
                .SetDefault("Edgy");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 6;
            item.vanity = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}
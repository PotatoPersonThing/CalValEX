using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class CoralMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Belching Coral Mask");
            Tooltip.SetDefault("Oh yeah its big brain time");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 5;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class ClamMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clamitous Hat");
            Tooltip.SetDefault("Wait a second, thats a typo right?");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            //item.height = 28;
            item.height = 50;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 2;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
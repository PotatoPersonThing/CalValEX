using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class Cryocap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryocap");
            Tooltip.SetDefault("Brain Freeze!");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 14;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
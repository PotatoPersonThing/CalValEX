using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    public class AstrachnidTentacles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrachnid Legs");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 7;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
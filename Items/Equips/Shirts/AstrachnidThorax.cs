using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class AstrachnidThorax : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrachnid Thorax");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 7;
            item.vanity = true;
        }
    }
}
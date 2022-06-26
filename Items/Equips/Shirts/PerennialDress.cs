using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class PerennialDress : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perennial Dress");
            Tooltip.SetDefault("Flowering out");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 6;
            Item.vanity = true;
        }
    }
}
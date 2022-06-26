using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    public class EarthenLeggings: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthen Leggings");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.rare = 4;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
        }
    }
}
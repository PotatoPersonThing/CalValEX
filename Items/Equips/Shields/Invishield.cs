using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shields {
    [AutoloadEquip(EquipType.Shield)]
    public class Invishield : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults() {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = -1;
        }
    }
}
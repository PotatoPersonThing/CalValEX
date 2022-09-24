using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Scarves
{
    [AutoloadEquip(EquipType.Neck)]
    public class DesertMedallion : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
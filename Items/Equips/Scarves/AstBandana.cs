using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Scarves
{
    [AutoloadEquip(EquipType.Neck)]
    public class AstBandana : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 6;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
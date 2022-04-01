using Terraria;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    [AutoloadEquip(EquipType.Head)]
    public class MeldosaurusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meldosaurus Mask");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 9;
            item.vanity = true;
        }
    }
}
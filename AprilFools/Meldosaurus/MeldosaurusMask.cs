using Terraria;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    [AutoloadEquip(EquipType.Head)]
    public class MeldosaurusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 9;
            Item.vanity = true;
        }
    }
}
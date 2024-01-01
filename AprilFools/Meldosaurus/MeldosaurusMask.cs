using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.AprilFools.Meldosaurus
{
    [AutoloadEquip(EquipType.Head)]
    public class MeldosaurusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.vanity = true;
        }
    }
}
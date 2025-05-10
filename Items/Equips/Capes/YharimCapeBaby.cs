using CalValEX.CalamityID;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Capes
{
    [AutoloadEquip(EquipType.Back)]
    public class YharimCapeBaby : ModItem {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults() {
            Item.width = 38;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalRarityID.HotPink;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}
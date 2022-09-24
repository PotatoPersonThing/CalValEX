using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Hats {
    [AutoloadEquip(EquipType.Head)]
    public class ProfanedCultistMask : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults() {
            Item.width = 30;
            Item.height = 32;
            Item.rare = ItemRarityID.Purple;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }

    }
}

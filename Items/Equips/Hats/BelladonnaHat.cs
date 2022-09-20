using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats {
    [AutoloadEquip(EquipType.Head)]
    public class BelladonnaHat : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Belladona Spirit Hat");
            Tooltip.SetDefault("Poisonous but stylish");
            SacrificeTotal = 1;
        }

        public override void SetDefaults() {
            Item.width = 28;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 1, 75, 0);
            Item.rare = ItemRarityID.Pink;
            Item.vanity = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
        }
    }
}
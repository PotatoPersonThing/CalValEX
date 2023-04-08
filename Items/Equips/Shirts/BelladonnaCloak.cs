using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Shirts {
    [AutoloadEquip(EquipType.Body, EquipType.Legs)]
    public class BelladonnaCloak : ModItem {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults() {
            Item.width = 38;
            Item.height = 24;
            Item.rare = ItemRarityID.Pink;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 5, 50, 5);
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesBottomSkin[Item.bodySlot] = true;
            ArmorIDs.Body.Sets.HidesTopSkin[Item.bodySlot] = true;
            ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
        }

        public override void UpdateEquip(Player player) => player.GetModPlayer<CalValEXPlayer>().bellaCloak = true;

        public override void UpdateVanity(Player player) => player.GetModPlayer<CalValEXPlayer>().bellaCloakHide = true;
    }
}
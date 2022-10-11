using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Shirts {
    [AutoloadEquip(EquipType.Body, EquipType.Legs)]
    public class BelladonnaCloak : ModItem {
        public override void SetStaticDefaults() {
            SacrificeTotal = 1;

            if (Main.netMode != NetmodeID.Server) {
                var legEquipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
                ArmorIDs.Legs.Sets.HidesBottomSkin[legEquipSlot] = true;
                var bodyEquipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
                ArmorIDs.Body.Sets.HidesArms[bodyEquipSlot] = true;
                ArmorIDs.Body.Sets.HidesHands[bodyEquipSlot] = true;
                ArmorIDs.Body.Sets.HidesBottomSkin[bodyEquipSlot] = true;
                ArmorIDs.Body.Sets.HidesTopSkin[bodyEquipSlot] = true;
            }
        }

        public override void SetDefaults() {
            Item.width = 38;
            Item.height = 24;
            Item.rare = ItemRarityID.Pink;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 5, 50, 5);
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = false;
        }

        public override void UpdateEquip(Player player) => player.GetModPlayer<CalValEXPlayer>().bellaCloak = true;

        public override void UpdateVanity(Player player) => player.GetModPlayer<CalValEXPlayer>().bellaCloakHide = true;
    }
}
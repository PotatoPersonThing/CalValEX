using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Shirts {
    [AutoloadEquip(EquipType.Body)]
    public class BelladonnaCloak : ModItem {
        public override void Load() {
            if (Main.netMode != NetmodeID.Server) { 
                EquipLoader.AddEquipTexture(Mod, "CalValEX/Items/Equips/Shirts/BelladonnaCloak_Legs", EquipType.Legs, this);
                EquipLoader.AddEquipTexture(Mod, "CalValEX/Items/Equips/Shirts/BelladonnaCloak_Front", EquipType.Front, this);
            }
        }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Belladonna Spirit Cloak");
            Tooltip.SetDefault("The latest fashion, all natural");
            SacrificeTotal = 1;

            if (Main.netMode != NetmodeID.Server) {
                var legEquipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
                ArmorIDs.Legs.Sets.HidesBottomSkin[legEquipSlot] = true;
                var cloakEquipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Front);
                ArmorIDs.Front.Sets.DrawsInNeckLayer[cloakEquipSlot] = true;
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
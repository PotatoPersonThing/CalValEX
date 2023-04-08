using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Shirts {
    [AutoloadEquip(EquipType.Body, EquipType.Legs)]
    public class ProfanedCultistRobes : ModItem {
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 1;

            if (Main.netMode != NetmodeID.Server) {
                var legEquipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
                ArmorIDs.Legs.Sets.HidesBottomSkin[legEquipSlot] = true;
                var bodyEquipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
                ArmorIDs.Body.Sets.HidesArms[bodyEquipSlot] = true;
            }
        }

        public override void SetDefaults() {
            Item.width = 34;
            Item.height = 30;
            Item.rare = ItemRarityID.Purple;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 75, 0);
        }

        public override void UpdateEquip(Player player) => player.GetModPlayer<CalValEXPlayer>().profanedCultist = true;

        public override void UpdateVanity(Player player) => player.GetModPlayer<CalValEXPlayer>().profanedCultistHide = true;
    }
}

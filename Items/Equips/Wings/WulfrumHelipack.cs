using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Wings {
    [AutoloadEquip(EquipType.Wings)]
    public class WulfrumHelipack : ModItem {
        public override void SetStaticDefaults() {
            SacrificeTotal = 1;
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new Terraria.DataStructures.WingStats(48, 1f, 1f);
        }

        public override void SetDefaults() {
            Item.width = 22;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateVanity(Player player) => player.GetModPlayer<CalValEXPlayer>().helipack = true;

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.wingTimeMax = 48;
            if (hideVisual)
                player.GetModPlayer<CalValEXPlayer>().wulfrumjam = false;
            else if (player.wingTime <= 0) {
                player.GetModPlayer<CalValEXPlayer>().wulfrumjam = true;
            }
            if (player.wingTime > 0) {
                player.GetModPlayer<CalValEXPlayer>().wulfrumjam = false;
            }

            if (!hideVisual || player.wingTime != player.wingTimeMax)
                player.GetModPlayer<CalValEXPlayer>().helipack = true;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
            if (player.wingTime == 0) {
                ascentWhenFalling = 0f;
                ascentWhenRising = 0f;
                maxCanAscendMultiplier = 0f;
                maxAscentMultiplier = 0f;
                constantAscend = 0f;
            } else {
                ascentWhenFalling = 0.55f;
                ascentWhenRising = 0.06f;
                maxCanAscendMultiplier = 0.6f;
                maxAscentMultiplier = 0.6f;
                constantAscend = 0.08f;
            }            
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
            speed = 5.8f;
            acceleration *= 0.8f;
        }
    }
}
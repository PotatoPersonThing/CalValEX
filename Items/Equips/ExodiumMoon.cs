using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips
{
    public class ExodiumMoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exodium Orbiter");
            Tooltip.SetDefault("A world revolving");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.accessory = true;
            item.vanity = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().exorb = true;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<CalValEXPlayer>().exorb = true;
        }
    }
}
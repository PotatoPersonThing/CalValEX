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
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.accessory = true;
            Item.vanity = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().exorb = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().exorb = true;
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class StonePile : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Pile");
            Tooltip.SetDefault("'Requires a strong head to wear'");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.vanity = true;
            Terraria.ID.ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().rockhat = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().rockhat = true;
        }
    }
}
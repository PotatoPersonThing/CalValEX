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
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 7;
            item.vanity = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().rockhat = true;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<CalValEXPlayer>().rockhat = true;
        }
    }
}
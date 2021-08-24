using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Backs
{
    public class PrismShell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prism Shell");
            Tooltip.SetDefault("'Lookin' sharp'");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 34;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.accessory = true;
            item.vanity = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!hideVisual)
            {
                player.GetModPlayer<CalValEXPlayer>().prismshell = true;
            }
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<CalValEXPlayer>().prismshell = true;
        }
    }
}
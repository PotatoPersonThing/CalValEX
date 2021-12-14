using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class ApolloBalloonSmall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'From the Moon, Knowledge'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 42;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.accessory = true;
            item.vanity = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().sapballoon = true;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<CalValEXPlayer>().sapballoon = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise) = new Color(0, 255, 200)
            //rarity 13 (Pure Green) = new Color(0, 255, 0)
            //rarity 14 (Dark Blue) = new Color(43, 96, 222)
            //rarity 15 (Violet) = new Color(108, 45, 199)
            //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
            //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
            //rarity rare variant = new Color(255, 140, 0)
            //rarity dedicated(patron items) = new Color(139, 0, 0)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(108, 45, 199); //change the color accordingly to above
                }
            }
        }
    }
}
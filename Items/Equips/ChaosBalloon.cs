using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Balloon)]
    public class ChaosBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Puffer Balloon");
            Tooltip.SetDefault("The Party Girl can tie this for you\n'May go off any minute now...'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Purple;
            item.accessory = true;
            item.vanity = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(0, 255, 0);
                }
            }
        }
    }
}
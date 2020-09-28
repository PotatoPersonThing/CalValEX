using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Paintings
{
    public class Snouts : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snouts");
            Tooltip.SetDefault("'Mathew Maple'");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<SnoutsPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 10;
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
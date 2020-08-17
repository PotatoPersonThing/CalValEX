using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class TheYhar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(":THE_YHAR:");
            Tooltip.SetDefault("You gotta admit, he's a very cool dude despite his crimes");
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
            item.createTile = ModContent.TileType<TheYharPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = ItemRarityID.Red;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(108, 45, 199);
                }
            }
        }
    }
}
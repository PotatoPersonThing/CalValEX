using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.MiscFurniture;
using Terraria;

namespace CalValEX.Items.Tiles
{
    internal class TerminusShrine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terminus Shrine");
            Tooltip.SetDefault("An altar made to hold the apocalyptic artifact\n" + "Placing a rock on it may have unforseen calamitous and monstrous consequences\n" + "REMOVE ALL ITEMS FROM THE SHRINE BEFORE EXITING YOUR WORLD OR ITEMS RISK BEING DELETED");

        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.width = 16;
            item.height = 28;
            item.rare = 10;
            item.createTile = ModContent.TileType<TerminusShrinePlaced>();
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
                    tooltipLine.overrideColor = new Color(255, 0, 255); //change the color accordingly to above
                }
            }
        }
    }
}

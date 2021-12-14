using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.Plants;
using Terraria.ModLoader;
using Terraria;

namespace CalValEX.Items.Tiles.Plants
{
    internal class OddMushroomPot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Odd Mushroom Pot");
            Tooltip.SetDefault("Now you can grow your own shrooms... well not really");
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
            item.createTile = ModContent.TileType<OddMushromPotPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 4;
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
                    tooltipLine.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB); //change the color accordingly to above
                }
            }
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Monoliths;

namespace CalValEX.Items.Tiles.Monoliths
{
    public class DimensionalMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dimensional Obelisk");
            Tooltip.SetDefault("It appears to be trying to signal something, with no success");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 32;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.createTile = ModContent.TileType<DimensionalMonolithPlaced>();
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
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(43, 96, 222); //change the color accordingly to above
                }
            }
        }
    }
}
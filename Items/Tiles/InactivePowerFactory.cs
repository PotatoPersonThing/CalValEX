using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Tiles
{
    public class InactivePowerFactory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inactive Power Cell Factory");
            Tooltip.SetDefault("An unpowered Power Cell Factory\n" + "Break to reactivate");
            SacrificeTotal = 1;
        }

        public override string Texture => "CalamityMod/Items/Placeables/DraedonStructures/PowerCellFactoryItem";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 16;
            Item.height = 28;
            Item.rare = 3;
            Item.createTile = ModContent.TileType<CalamityMod.Tiles.DraedonStructures.InactivePowerCellFactory>();
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
                    tooltipLine.OverrideColor = new Color(204, 71, 35); //change the color accordingly to above
                }
            }
        }
    }
}

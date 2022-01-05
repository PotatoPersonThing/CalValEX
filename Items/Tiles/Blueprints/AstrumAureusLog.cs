using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.Blueprints;

namespace CalValEX.Items.Tiles.Blueprints
{
    public class AstrumAureusLog : ModItem
    {
        public override string Texture => "CalValEX/Items/Tiles/Blueprints/Blueprint";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrum Aureus Blueprint");
            Tooltip
                .SetDefault("Do Not Distribute");
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
            item.createTile = ModContent.TileType<AstrumAureusBlueprintPlaced>();
            item.width = 46;
            item.height = 32;
            item.rare = 7;
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
                    tooltipLine.overrideColor = new Color(204, 71, 35); //change the color accordingly to above
                }
            }
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralJelly"), 1);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PowerCell"), 10);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("LaboratoryConsole"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
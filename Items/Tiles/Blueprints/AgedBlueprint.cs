using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.Blueprints;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Blueprints
{
    public class AgedBlueprint : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aged Blueprint");
            /* Tooltip
                .SetDefault("Do Not Distribute?"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AgedLogPlaced>();
            Item.width = 46;
            Item.height = 32;
            Item.rare = CalamityID.CalRarityID.DarkOrange;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PowerCell"), 10);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("LaboratoryConsole"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
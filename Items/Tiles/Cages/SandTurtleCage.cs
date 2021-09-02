using CalValEX.Items.Critters;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    internal class SandTurtleCage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Turtle Cage");
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
            item.createTile = ModContent.TileType<SandTurtleCagePlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 4;
            item.value = Item.sellPrice(0, 0, 10, 0);
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<SandTurtleItem>());
                recipe.AddIngredient((ItemID.Terrarium), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
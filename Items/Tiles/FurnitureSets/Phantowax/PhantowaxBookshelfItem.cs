﻿using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
    internal class PhantowaxBookshelfItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantowax Bookshelf");
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
            item.createTile = ModContent.TileType<PhantowaxBookshelf>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.Book), 10);
                recipe.AddIngredient(ModContent.ItemType<PhantowaxBlock>(), 20);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
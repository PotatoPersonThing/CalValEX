﻿using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Astral;

namespace CalValEX.Items.Tiles.FurnitureSets.Astral
{
    public class OldAstralBookshelfItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Xenomonolith Bookcase");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<OldAstralBookshelf>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.White;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.Book), 10);
                recipe.AddIngredient(ModContent.ItemType<AstralTreeWood>(), 20);
                recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe.SetResult(this);
                recipe.AddRecipe();

                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MonolithBookcase"));
                recipe2.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }*/
    }
}
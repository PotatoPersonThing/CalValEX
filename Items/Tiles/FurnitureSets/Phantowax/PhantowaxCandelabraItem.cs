using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Tiles;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using CalValEX.Items.Tiles.FurnitureSets.Phantowax;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
    internal class PhantowaxCandelabraItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantowax Candelabra");
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
            item.createTile = ModContent.TileType<PhantowaxCandelabra>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm"), 3);
                recipe.AddIngredient(ModContent.ItemType<PhantowaxBlock>(), 5);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
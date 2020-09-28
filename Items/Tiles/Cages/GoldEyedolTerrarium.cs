using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items.Critters;
using CalValEX.Items.Tiles;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;

namespace CalValEX.Items.Tiles.Cages
{
    internal class GoldEyedolTerrarium : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gold Eyedol Cage");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<GoldEyedolTerrariumPlaced>();
			item.width = 32;
			item.height = 28;
            item.rare = 3;
		}

 public override void AddRecipes()
    {
    Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<GoldEyedolItem>());
                recipe.AddIngredient((ItemID.Terrarium), 1);
            	recipe.AddIngredient(ItemID.IronBar, 3);
            	recipe.anyIronBar = true;
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
    }
}}
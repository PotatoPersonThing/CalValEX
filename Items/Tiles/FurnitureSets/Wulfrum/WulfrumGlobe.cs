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

namespace CalValEX.Items.Tiles.FurnitureSets.Wulfrum
{
    internal class WulfrumGlobe : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wulfrum Globe");
            Tooltip.SetDefault("Spin spin spin");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<WulfrumGlobePlaced>();
			item.width = 12;
			item.height = 12;
            item.rare = 2;
		}

 public override void AddRecipes()
    {
    Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("WulfrumShard"), 5);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("EnergyCore"), 1);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
    }
}}

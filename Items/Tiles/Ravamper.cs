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

namespace CalValEX.Items.Tiles
{
    internal class Ravamper : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Necrotic Bonfire");
            Tooltip
                .SetDefault("Praise the sun!");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<RavamperPlaced>();
			item.width = 12;
			item.height = 12;
            item.rare = 9;
		}
	


public override void AddRecipes()
    {
    Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(mod.ItemType("Necrostone"), 20);
				recipe.AddIngredient(mod.ItemType("NecroticTorch"), 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
    }
}}

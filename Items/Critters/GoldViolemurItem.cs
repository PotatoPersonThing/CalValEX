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
using CalValEX.Items.Critters;

namespace CalValEX.Items.Critters
{
internal class GoldViolemurItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gold Violemur");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 22;
			item.height = 18;
			item.noUseGraphic = true;
			item.rare = 4;

			Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }
			item.makeNPC = (short)NPCType<GoldViolemur>();
			item.value = Item.sellPrice(0, 10, 0, 0);
		}

		public override void AddRecipes()
		{
			Mod mod = ModLoader.GetMod("FargowiltasSouls");
			if (mod == null)
			{
				return;
			}
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<ViolemurItem>());
				recipe.AddIngredient((ItemID.GoldDust), 500);
				recipe.AddTile(mod.TileType("GoldenDippingVatSheet"));
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
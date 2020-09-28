using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using CalValEX.Items.Critters;

namespace CalValEX.Items.Tiles.Statues
{

	public class ViolemurStatue : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Violemur Statue");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ArmorStatue);
			item.createTile = TileType<ViolemurStatuePlaced>();
			item.placeStyle = 0;
		}

        public override void AddRecipes()
    {
    Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<ViolemurItem>(), 5);
                recipe.AddIngredient((ItemID.StoneBlock), 50);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
    }
	}
}
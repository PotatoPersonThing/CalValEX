using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;
using CalValEX.Items.Hooks;

namespace CalValEX.Items.Equips
{
	[AutoloadEquip(EquipType.Shield)]
	public class Invishield : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Glass Shield");
			Tooltip.SetDefault("So weak that it doesn't even appear!");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 0, 0, 5);
			item.rare = 1;
			item.accessory = true;
            item.vanity = true;
		}

        public override void AddRecipes()
    {
    Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.Glass), 20);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
    }
	}
}

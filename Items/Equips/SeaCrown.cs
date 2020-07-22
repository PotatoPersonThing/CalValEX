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
	[AutoloadEquip(EquipType.Head)]
	public class SeaCrown : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sea Empress Crown");
            Tooltip.SetDefault("Wearing this will make you feel royal");
		}
		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.rare = 2;
			item.vanity = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

        public override void AddRecipes()
        {
        Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SeaPrism"), 5);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PrismShard"), 30);
                recipe.AddIngredient(ItemID.PlatinumCrown, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SeaPrism"), 5);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PrismShard"), 30);
                recipe.AddIngredient(ItemID.GoldCrown, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
        }
	}
}
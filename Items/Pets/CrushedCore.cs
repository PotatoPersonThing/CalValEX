using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalValEX;
using CalValEX.Items.Tiles.Plants;

namespace CalValEX.Items.Pets {
	public class CrushedCore : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sand Shark Filet");
			Tooltip.SetDefault("Too broken to attract the great beast again\nbut can attract another...");
		}

		public override void SetDefaults() {
		item.CloneDefaults(ItemID.ZephyrFish);
		item.UseSound = SoundID.NPCHit21;
		item.shoot = mod.ProjectileType("GrandPet");
		item.value = Item.sellPrice(0, 0, 50, 0);
		item.rare = 7;
		item.buffType = mod.BuffType("GrandBuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		public override void AddRecipes()
        {
        Mod CalValEX = ModLoader.GetMod("CalamityMod");
                {
                    ModRecipe recipe = new ModRecipe(mod);
					recipe.AddIngredient((ItemID.AncientBattleArmorMaterial), 10);
					recipe.AddIngredient((ItemID.Bass), 1);
                    recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("GrandScale"), 5);
                    recipe.AddTile(mod.TileType("BelchingCoralPlaced"));
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
        }
	}
}
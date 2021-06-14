using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;

namespace CalValEX.Items.Equips.Transformations
{
	public class Signus: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Charm");
			Tooltip.SetDefault("'One with the void'\n" + "Transforms the wearer into a nether spirit");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.accessory = true;
			item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			CalValEXPlayer p = player.GetModPlayer<CalValEXPlayer>();
			p.signutTrans = true;
			if (hideVisual)
			{
				p.signutHide = true;
			}
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			//rarity 12 (Turquoise) = new Color(0, 255, 200)
			//rarity 13 (Pure Green) = new Color(0, 255, 0)
			//rarity 14 (Dark Blue) = new Color(43, 96, 222)
			//rarity 15 (Violet) = new Color(108, 45, 199)
			//rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
			//rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
			//rarity rare variant = new Color(255, 140, 0)
			//rarity dedicated(patron items) = new Color(139, 0, 0)
			//look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
			foreach (TooltipLine tooltipLine in tooltips)
			{
				if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
				{
					tooltipLine.overrideColor = new Color(0, 255, 0); //change the color accordingly to above
				}
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				recipe.AddIngredient(calamityMod.ItemType("SignusMask"), 1);
				recipe.AddIngredient(mod.ItemType("SigCape"), 1);
				recipe.AddIngredient(mod.ItemType("SignusNether"), 1);
				recipe.AddIngredient(mod.ItemType("SignusEmblem"), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}

	public class SignusHead : EquipTexture
	{
		public override bool DrawHead()
		{
			return false;
		}
	}

	public class SignusBody : EquipTexture
	{
		public override bool DrawBody()
		{
			return false;
		}
	}

	public class SignusLegs : EquipTexture
	{
		public override bool DrawLegs()
		{
			return false;
		}
	}
}
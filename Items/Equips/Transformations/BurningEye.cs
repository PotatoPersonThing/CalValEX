using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Legs;

namespace CalValEX.Items.Equips.Transformations
{
	public class BurningEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Eye");
			Tooltip.SetDefault("Engulfs the wearer in Brimstone Flames");
			ItemID.Sets.ItemNoGravity[item.type] = true;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.accessory = true;
			item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			CalValEXPlayer p = player.GetModPlayer<CalValEXPlayer>();
			p.classicTrans = true;
			if (hideVisual)
			{
				p.classicHide = true;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				recipe.AddIngredient(calamityMod.ItemType("BrimstoneWaifuMask"), 1);
				recipe.AddIngredient(mod.ItemType("BrimmyBody"), 1);
				recipe.AddIngredient(mod.ItemType("BrimmySpirit"), 1);
				recipe.AddIngredient(calamityMod.ItemType("UnholyCore"), 5);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}

	public class ClassicBrimmyHead : EquipTexture
	{
		public override bool DrawHead()
		{
			return false;
		}
	}

	public class ClassicBrimmyBody : EquipTexture
	{
		public override bool DrawBody()
		{
			return false;
		}
	}

	public class ClassicBrimmyLegs : EquipTexture
	{
		public override bool DrawLegs()
		{
			return false;
		}
	}
}
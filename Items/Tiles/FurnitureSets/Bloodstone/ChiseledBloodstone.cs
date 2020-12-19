using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
	public class ChiseledBloodstone : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Used to make Bloodstone furniture");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.rare = 0;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<ChiseledBloodstoneTile>();
		}

		public override void AddRecipes()
		{

			Mod CalValEX = ModLoader.GetMod("CalamityMod");
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient((ItemID.StoneBlock), 200);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodstoneCore"), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.SetResult(this, 200);
				recipe.AddRecipe();
				ModRecipe recipe3 = new ModRecipe(mod);
				recipe3.AddIngredient(ModContent.ItemType<BloodstonePlatformItem>(), 2);
				recipe3.AddTile(TileID.WorkBenches);
				recipe3.SetResult(this, 1);
				recipe3.AddRecipe();
				/*ModRecipe recipe2 = new ModRecipe(mod);
				recipe2.AddIngredient(ModContent.ItemType<ChiseledBloodstoneWall>(), 4);
				recipe2.AddTile(TileID.WorkBenches);
				recipe2.SetResult(this, 4);
				recipe2.AddRecipe();*/
			}
		}
	}
}
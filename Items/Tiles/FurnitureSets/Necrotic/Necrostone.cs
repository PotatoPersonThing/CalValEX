using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.FurnitureSets.Necrotic;

namespace CalValEX.Items.Tiles.FurnitureSets.Necrotic
{
	public class Necrostone : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
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
			item.createTile = ModContent.TileType<NecrostonePlaced>();
		}

		public override void AddRecipes() {
			Mod CalValEX = ModLoader.GetMod("CalamityMod");
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<NecrostoneWall>(), 4);
				recipe.AddTile(TileID.WorkBenches);
				recipe.SetResult(this, 1);
				recipe.AddRecipe();
				ModRecipe recipe2 = new ModRecipe(mod);
				recipe2.AddIngredient((ItemID.StoneBlock), 200);
				recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("FleshyGeodeT1"), 1);
				recipe2.AddTile(TileID.MythrilAnvil);
				recipe2.SetResult(this, 200);
				recipe2.AddRecipe();
				ModRecipe recipe3 = new ModRecipe(mod);
				recipe3.AddIngredient((ItemID.StoneBlock), 200);
				recipe3.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("FleshyGeodeT2"), 1);
				recipe3.AddTile(TileID.LunarCraftingStation);
				recipe3.SetResult(this, 200);
				recipe3.AddRecipe();
        }
	}
}
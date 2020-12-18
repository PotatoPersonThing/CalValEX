using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.FurnitureSets.Necrotic;

namespace CalValEX.Items.Tiles.FurnitureSets.Necrotic
{
	public class NecrostoneWall : ModItem
	{

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
            item.rare = 0;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createWall = ModContent.WallType<NecrostoneWallPlaced>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Necrostone>());
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}
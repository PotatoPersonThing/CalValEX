using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
	public class YellowSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yellow Solution");
			Tooltip.SetDefault("Used by the Clentaminator"
				+ "\nPurifies the Astral Blight");
		}

		public override void SetDefaults()
		{
			item.shoot = ModContent.ProjectileType<YellowSolutionProj>() - ProjectileID.PureSpray;
			item.ammo = AmmoID.Solution;
			item.width = 10;
			item.height = 12;
			item.value = Item.buyPrice(0, 0, 25, 0);
			item.rare = 4;
			item.maxStack = 999;
			item.consumable = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<XenoSolution>(), 1);
			recipe.AddIngredient(ItemID.GreenSolution);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}
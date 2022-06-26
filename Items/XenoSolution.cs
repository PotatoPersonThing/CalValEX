using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles;

namespace CalValEX.Items
{
	public class XenoSolution : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blighted Astral Solution");
			Tooltip.SetDefault("Used by the Clentaminator"
				+ "\nSpreads the Astral Blight");
			SacrificeTotal = 99;
		}

		public override void SetDefaults() {
			Item.shoot = ModContent.ProjectileType<AstralSolutionProj>() - ProjectileID.PureSpray;
			Item.ammo = AmmoID.Solution;
			Item.width = 10;
			Item.height = 12;
			Item.value = Item.buyPrice(0, 0, 25, 0);
			Item.rare = 4;
			Item.maxStack = 999;
			Item.consumable = true;
		}

		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExampleItem>(), 1);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}*/
	}
}
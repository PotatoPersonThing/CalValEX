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
				+ "\nSpreads the Astral Blight"
				+ "\nDoes not affect overworld spawns");
		}

		public override void SetDefaults() {
			item.shoot = ModContent.ProjectileType<AstralSolutionProj>() - ProjectileID.PureSpray;
			item.ammo = AmmoID.Solution;
			item.width = 10;
			item.height = 12;
			item.value = Item.buyPrice(0, 0, 25, 0);
			item.rare = 4;
			item.maxStack = 999;
			item.consumable = true;
		}

		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExampleItem>(), 1);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}*/
	}
}
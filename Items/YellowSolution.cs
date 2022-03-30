using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles;

namespace CalValEX.Items
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
			Item.shoot = ModContent.ProjectileType<YellowSolutionProj>() - ProjectileID.PureSpray;
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
			recipe.AddIngredient(ModContent.ItemType<XenoSolution>(), 1);
			recipe.AddIngredient(ItemID.GreenSolution);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}*/
	}
}
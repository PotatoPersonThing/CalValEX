using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalValEX
{
	public class CalValEXRecipes : ModSystem
	{

		public override void AddRecipes()
		{
					
			Recipe recipe = Mod.CreateRecipe(ItemID.Zenith, 1);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.Meowmere);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(ItemID.InfluxWaver);
			recipe.AddIngredient(ItemID.TheHorsemansBlade);
			recipe.AddIngredient(ItemID.Seedler);
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddIngredient(ItemID.BeeKeeper);
			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.CopperShortsword);
			recipe.Register();


		}
	}
}
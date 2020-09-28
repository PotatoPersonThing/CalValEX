using CalValEX.Items.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using CalValEX.Items.Critters;

namespace CalValEX.Items.Tiles.Cages
{
	public class NukeJar : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Vaporofly in a Jar");
        }
		// The tooltip for this item is automatically assigned from .lang files
		public override void SetDefaults() {
			item.width = 10;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = TileType<NukeJarPlaced>();
			item.placeStyle = 0;
		}

        public override void AddRecipes()
    {
    Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<NukeFlyItem>());
                recipe.AddIngredient((ItemID.Bottle), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
    }
	}
}
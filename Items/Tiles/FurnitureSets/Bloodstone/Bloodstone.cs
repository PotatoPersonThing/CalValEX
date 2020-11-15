using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
    public class Bloodstone : ModItem
    {
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bloodstone Block");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.rare = 0;
			item.useTurn = true;
			item.rare = 0;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<BloodstonePlaced>();
		}

		public override void AddRecipes()
        {

        	Mod CalValEX = ModLoader.GetMod("CalamityMod");
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Bloodstone"), 1);
                    recipe.AddTile(TileID.LunarCraftingStation);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
        }
    }
}

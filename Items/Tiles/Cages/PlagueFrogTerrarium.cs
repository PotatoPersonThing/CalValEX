using CalValEX.Items.Critters;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Cages
{
    internal class PlagueFrogTerrarium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plagued Frog Cage");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<PlagueFrogTerrariumPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 8;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<PlagueFrogItem>());
                recipe.AddIngredient((ItemID.Terrarium), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
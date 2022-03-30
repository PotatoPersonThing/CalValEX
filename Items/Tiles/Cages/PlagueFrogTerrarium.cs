using CalValEX.Items.Critters;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class PlagueFrogTerrarium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plagued Frog Cage");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<PlagueFrogTerrariumPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 8;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<PlagueFrogItem>());
                recipe.AddIngredient((ItemID.Terrarium), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
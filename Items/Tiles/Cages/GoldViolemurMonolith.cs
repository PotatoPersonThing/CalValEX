using CalValEX.Items.Critters;
using CalValEX.Items.Tiles.Plants;
using Terraria.ModLoader;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class GoldViolemurMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Violemur Perch");
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
            Item.createTile = ModContent.TileType<GoldViolemurMonolithPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 4;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<GoldViolemurItem>());
                recipe.AddIngredient(ModContent.ItemType<MonolithPot>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
using CalValEX.Items.Critters;
using CalValEX.Items.Tiles.Plants;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Cages
{
    internal class ViolemurMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Violemur Perch");
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
            item.createTile = ModContent.TileType<ViolemurMonolithPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<ViolemurItem>());
                recipe.AddIngredient(ModContent.ItemType<MonolithPot>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
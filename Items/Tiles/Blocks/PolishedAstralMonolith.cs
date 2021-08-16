using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Blocks
{
    public class PolishedAstralMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Polished Astral Monolith");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<PolishedAstralMonolithPlaced>();
        }
        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralMonolith"));
                recipe.AddTile(TileID.Sawmill);
                recipe.SetResult(this);
                recipe.AddRecipe();
                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(mod.ItemType("PolishedXenomonolith"));
                recipe2.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }
    }
}
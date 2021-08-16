using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class PolishedXenomonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Polished Xenomonolith");
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
            item.createTile = ModContent.TileType<PolishedXenomonolithPlaced>();
        }
        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.ItemType("AstralTreeWood"));
                recipe.AddTile(TileID.Sawmill);
                recipe.SetResult(this);
                recipe.AddRecipe();
                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(mod.ItemType("PolishedAstralMonolith"));
                recipe2.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }
    }
}
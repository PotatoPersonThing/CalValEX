using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Astral;

namespace CalValEX.Items.Tiles.Astral.Furniture
{
    internal class OldAstralTableItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomonolith Table");
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
            item.createTile = ModContent.TileType<OldAstralTable>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<AstralTreeWood>(), 8);
                recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe.SetResult(this);
                recipe.AddRecipe();

                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MonolithTable"));
                recipe2.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }
    }
}
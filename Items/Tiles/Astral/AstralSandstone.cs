using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralSandstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blighted Astral Sandstone");
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
            item.createTile = ModContent.TileType<AstralSandstonePlaced>();
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralSandstone"));
                recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe.SetResult(this);
                recipe.AddRecipe();
                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(mod.ItemType("AstralSandstoneWall"), 4);
                recipe2.AddTile(TileID.WorkBenches);
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }
    }
}
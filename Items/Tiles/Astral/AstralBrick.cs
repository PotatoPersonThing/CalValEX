using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralBrick : ModItem
    {
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
            item.createTile = ModContent.TileType<AstralBrickPlaced>();
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.StoneBlock), 1);
                recipe.AddIngredient(ModContent.ItemType<Xenostone>(), 1);
                recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;
using CalValEX.Items.Walls;

namespace CalValEX.Items.Tiles.Blocks
{
    public class AuricBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.rare = 0;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<AuricBrickPlaced>();
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient((ItemID.StoneBlock));
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AuricOre"), 1);
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModContent.ItemType<AuricBrickWall>(), 4);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.SetResult(this, 4);
            recipe2.AddRecipe();
        }
    }
}
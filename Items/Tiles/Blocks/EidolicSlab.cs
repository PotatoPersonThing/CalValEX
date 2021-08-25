using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class EidolicSlab : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eidolic Slab");
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
            item.createTile = ModContent.TileType<EidolicSlabPlaced>();
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Lumenite"), 1);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("VoidstoneSlab"), 10);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ReaperTooth"), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}
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
            SacrificeTotal = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.rare = 0;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<EidolicSlabPlaced>();
        }

        /*
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Lumenite"), 1);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("VoidstoneSlab"), 10);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ReaperTooth"), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModContent.ItemType<Items.Walls.EidolicSlabWall>(), 4);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }*/
    }
}
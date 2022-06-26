using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.AstralBlocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class PolishedXenomonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Polished Xenomonolith");
            SacrificeTotal = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<PolishedXenomonolithPlaced>();
        }
        /*
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
                ModRecipe recipe3 = new ModRecipe(mod);
                recipe3.AddIngredient(ModContent.ItemType<Items.Walls.PolishedXenomonolithWall>(), 4);
                recipe3.AddTile(TileID.WorkBenches);
                recipe3.SetResult(this, 1);
                recipe3.AddRecipe();
            }
        }*/
    }
}
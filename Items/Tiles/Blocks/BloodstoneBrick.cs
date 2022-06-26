using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class BloodstoneBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 100;
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.rare = 0;
            Item.useTurn = true;
            Item.rare = 0;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<BloodstoneBrickPlaced>();
        }

        /*
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.StoneBlock), 200);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodstoneCore"), 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this, 200);
                recipe.AddRecipe();
                /*ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(ModContent.ItemType<BloodstoneBrickWall>(), 4);
                recipe2.AddTile(TileID.WorkBenches);
                recipe2.SetResult(this, 4);
                recipe2.AddRecipe();
            }
        }*/
    }
}
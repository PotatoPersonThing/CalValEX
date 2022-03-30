using Terraria.ID;
using Terraria.ModLoader;

using CalValEX.Tiles.Blocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class WulfrumPlating : ModItem
    {
        public override void SetStaticDefaults()
        {
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
            Item.createTile = ModContent.TileType<WulfrumPlatingPlaced>();
        }

        /*
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient((ItemID.StoneBlock), 50);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("WulfrumShard"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModContent.ItemType<WulfrumPanelWall>(), 4);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }*/
    }
}
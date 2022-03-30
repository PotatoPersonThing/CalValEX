using Terraria.ID;
using Terraria.ModLoader;

using CalValEX.Tiles.Blocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class Necrostone : ModItem
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
            Item.createTile = ModContent.TileType<NecrostonePlaced>();
        }

        /*
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NecrostoneWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient((ItemID.StoneBlock), 200);
            recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("FleshyGeodeT1"), 1);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.SetResult(this, 200);
            recipe2.AddRecipe();
            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient((ItemID.StoneBlock), 200);
            recipe3.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("FleshyGeodeT2"), 1);
            recipe3.AddTile(TileID.LunarCraftingStation);
            recipe3.SetResult(this, 200);
            recipe3.AddRecipe();
        }*/
    }
}
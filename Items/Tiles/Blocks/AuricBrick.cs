using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class AuricBrick : ModItem
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
            Item.createTile = ModContent.TileType<AuricBrickPlaced>();
        }

        /*
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient((ItemID.StoneBlock));
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AuricOre"), 1);
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("CosmicAnvil"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModContent.ItemType<AuricBrickWall>(), 4);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.SetResult(this, 4);
            recipe2.AddRecipe();
            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(ModContent.ItemType<AuricPlatformItem>(), 2);
            recipe3.AddTile(TileID.WorkBenches);
            recipe3.SetResult(this);
            recipe3.AddRecipe();
        }*/
    }
}
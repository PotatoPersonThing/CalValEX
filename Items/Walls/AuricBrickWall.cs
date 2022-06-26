using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Walls;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Items.Walls
{
    public class AuricBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Brick Wall");
            SacrificeTotal = 400;
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
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<AuricBrickWallPlaced>();
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AuricBrick>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }*/
    }
}
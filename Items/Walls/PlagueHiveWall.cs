using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Walls;

namespace CalValEX.Items.Walls
{
    public class PlagueHiveWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Hive Wall");
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
            Item.createWall = ModContent.WallType<PlagueHiveWallPlaced>();
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            recipe.AddIngredient(calamityMod.ItemType("PlagueCellCluster"), 1);
            recipe.AddIngredient((ItemID.HiveWall), 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }*/
    }
}
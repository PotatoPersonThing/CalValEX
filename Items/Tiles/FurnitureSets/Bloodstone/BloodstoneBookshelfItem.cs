using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Tiles.FurnitureSets.Bloodstone;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
    public class BloodstoneBookshelfItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodstone Bookcase");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<BloodstoneBookshelf>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 0;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.Book), 10);
                recipe.AddIngredient(ModContent.ItemType<ChiseledBloodstone>(), 20);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
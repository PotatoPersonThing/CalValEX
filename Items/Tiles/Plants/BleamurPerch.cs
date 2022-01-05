using CalValEX.Items.Critters;
using CalValEX.Items.Tiles.Plants;
using Terraria.ModLoader;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class BleamurPerch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bleamur Perch");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<BleamurPerchPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<BlightolemurItem>());
                recipe.AddIngredient(ModContent.ItemType<AstralOldPurple>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
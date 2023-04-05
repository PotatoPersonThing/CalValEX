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
            // DisplayName.SetDefault("Bleamur Perch");
            Item.ResearchUnlockCount = 1;
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
            Item.createTile = ModContent.TileType<BleamurPerchPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 4;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<BlightolemurItem>());
                recipe.AddIngredient(ModContent.ItemType<AstralOldPurple>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
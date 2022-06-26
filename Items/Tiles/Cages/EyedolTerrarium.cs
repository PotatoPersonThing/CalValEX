using CalValEX.Items.Critters;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class EyedolTerrarium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eyedol Cage");
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
            Item.createTile = ModContent.TileType<EyedolTerrariumPlaced>();
            Item.width = 32;
            Item.height = 28;
            Item.rare = 3;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<EyedolItem>());
                recipe.AddIngredient((ItemID.Terrarium), 1);
                recipe.AddIngredient(ItemID.IronBar, 3);
                recipe.anyIronBar = true;
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
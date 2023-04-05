using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Critters;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class BlinkerInABottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blinker in a Bottle");
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
            Item.createTile = ModContent.TileType<BlinkerInABottlePlaced>();
            Item.width = 20;
            Item.height = 26;
            Item.rare = 0;
        }

        /*public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<BlinkerItem>());
                recipe.AddIngredient((ItemID.Bottle), 1);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
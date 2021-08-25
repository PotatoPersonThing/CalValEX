using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Critters;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    internal class BlinkerInABottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blinker in a Bottle");
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
            item.createTile = ModContent.TileType<BlinkerInABottlePlaced>();
            item.width = 20;
            item.height = 26;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<BlinkerItem>());
                recipe.AddIngredient((ItemID.Bottle), 1);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
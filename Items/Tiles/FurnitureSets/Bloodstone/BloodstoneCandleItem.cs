using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
    internal class BloodstoneCandleItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodstone Candle");
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
            item.createTile = ModContent.TileType<BloodstoneCandle>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodOrb"), 1);
                recipe.AddIngredient(ModContent.ItemType<ChiseledBloodstone>(), 4);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
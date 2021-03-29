using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
    internal class PhantowaxClockItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantowax Grandfather Clock");
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
            item.createTile = ModContent.TileType<PhantowaxClock>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.IronBar), 3);
                recipe.AddIngredient(ModContent.ItemType<PhantowaxBlock>(), 10);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();

                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient((ItemID.LeadBar), 3);
                recipe2.AddIngredient(ModContent.ItemType<PhantowaxBlock>(), 10);
                recipe2.AddTile(TileID.LunarCraftingStation);
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }
    }
}
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
    public class PhantowaxChestItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantowax Chest");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 500;
            item.createTile = ModContent.TileType<PhantowaxChest>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm"), 4);
            recipe.AddIngredient(ModContent.ItemType<PhantowaxBlock>(), 4);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
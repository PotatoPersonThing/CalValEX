using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Tiles.FurnitureSets.Bloodstone;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
    public class BloodstoneChestItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodstone Chest");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 500;
            Item.createTile = ModContent.TileType<BloodstoneChest>();
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodOrb"), 5);
            recipe.AddIngredient(ModContent.ItemType<ChiseledBloodstone>(), 15);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
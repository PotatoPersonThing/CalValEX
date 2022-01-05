using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class Help : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stuck Orthocera");
            Tooltip
                .SetDefault("Help me\n" + "Can be fed Green Mushrooms");
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
            item.createTile = ModContent.TileType<Helplaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 5;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("EssenceofChaos"), 3);
                recipe.AddIngredient(ModContent.ItemType<Help>());
                recipe.AddTile(TileID.CookingPots);
                recipe.SetResult(ModLoader.GetMod("CalamityMod").ItemType("SunkenStew"), 1);
                recipe.AddRecipe();
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<Help>());
                recipe.AddTile(TileID.MeatGrinder);
                recipe.SetResult(ModLoader.GetMod("CalamityMod").ItemType("BloodOrb"), 8);
                recipe.AddRecipe();
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<Help>());
                recipe.AddTile(TileID.Sawmill);
                recipe.SetResult(ModLoader.GetMod("CalamityMod").ItemType("SulfuricScale"), 2);
                recipe.AddRecipe();
            }
        }
    }
}
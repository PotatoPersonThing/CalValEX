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
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Helplaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 5;
        }

        /*public override void AddRecipes()
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
        }*/
    }
}
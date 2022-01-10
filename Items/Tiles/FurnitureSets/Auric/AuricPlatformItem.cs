using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Auric;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricPlatformItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chiseled Auric Platform");
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
            item.createTile = ModContent.TileType<AuricPlatform>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(calamityMod.ItemType("CosmilitePlatform"), 30);
                recipe.AddIngredient(ModContent.ItemType<Items.Tiles.FurnitureSets.Bloodstone.BloodstonePlatformItem>(), 30);
                recipe.AddIngredient(calamityMod.ItemType("BotanicPlatform"), 30);
                recipe.AddIngredient(calamityMod.ItemType("SilvaPlatform"), 30);
                recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 1);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("CosmicAnvil"));
                recipe.SetResult(this, 30);
                recipe.AddRecipe();
            }
        }
    }
}
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Auric;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricPlatformItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Chiseled Auric Platform");
            Item.ResearchUnlockCount = 200;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AuricPlatform>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.White;
        }

        /*public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(calamityMod.ItemType("CosmilitePlatform"), 30);
                recipe.AddIngredient(ModContent.ItemType<Items.Tiles.FurnitureSets.Bloodstone.BloodstonePlatformItem>(), 30);
                recipe.AddIngredient(calamityMod.ItemType("BotanicPlatform"), 30);
                recipe.AddIngredient(calamityMod.ItemType("SilvaPlatform"), 30);
                recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 1);
                recipe.AddTile(ModContent.TileType<AuricManufacturerPlaced>());
                recipe.SetResult(this, 30);
                recipe.AddRecipe();
            }
        }*/
    }
}
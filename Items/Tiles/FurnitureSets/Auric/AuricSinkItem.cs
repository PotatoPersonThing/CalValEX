using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Auric;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricSinkItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Sink");
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
            Item.createTile = ModContent.TileType<AuricSink>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 0;
        }

        /*public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(calamityMod.ItemType("CosmiliteSink"));
                recipe.AddIngredient(ModContent.ItemType<Items.Tiles.FurnitureSets.Bloodstone.BloodstoneSinkItem>());
                recipe.AddIngredient(calamityMod.ItemType("BotanicSink"));
                recipe.AddIngredient(calamityMod.ItemType("SilvaSink"));
                recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 6);
                recipe.AddTile(ModContent.TileType<AuricManufacturerPlaced>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
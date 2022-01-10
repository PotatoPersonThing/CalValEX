using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Tiles.FurnitureSets.Auric;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricCandelabraItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Candelabra");
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
            item.createTile = ModContent.TileType<AuricCandelabra>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(calamityMod.ItemType("CosmiliteCandelabra"));
                recipe.AddIngredient(ModContent.ItemType<Items.Tiles.FurnitureSets.Bloodstone.BloodstoneCandelabraItem>());
                recipe.AddIngredient(calamityMod.ItemType("BotanicCandelabra"));
                recipe.AddIngredient(calamityMod.ItemType("SilvaCandelabra"));
                recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 5);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("CosmicAnvil"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
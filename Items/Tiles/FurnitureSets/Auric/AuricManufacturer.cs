using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Auric;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricManufacturer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Manufacturer");
            Tooltip.SetDefault("Used for special crafting");
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
            item.createTile = ModContent.TileType<AuricManufacturerPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 10);
                recipe.AddIngredient(calamityMod.ItemType("AscendantSpiritEssence"), 4);
                recipe.AddTile(calamityMod.TileType("CosmicAnvil"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}

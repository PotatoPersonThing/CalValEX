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
            SacrificeTotal = 1;
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
            Item.createTile = ModContent.TileType<AuricManufacturerPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 0;
        }

        /*public override void AddRecipes()
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
        }*/
    }
}

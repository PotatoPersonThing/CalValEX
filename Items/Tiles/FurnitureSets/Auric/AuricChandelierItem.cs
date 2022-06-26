using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Tiles.FurnitureSets.Auric;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricChandelierItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Chandelier");
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
            Item.createTile = ModContent.TileType<AuricChandelier>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 0;
        }

        /*public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(calamityMod.ItemType("CosmiliteChandelier"));
                recipe.AddIngredient(ModContent.ItemType<Items.Tiles.FurnitureSets.Bloodstone.BloodstoneChandelierItem>());
                recipe.AddIngredient(calamityMod.ItemType("BotanicChandelier"));
                recipe.AddIngredient(calamityMod.ItemType("SilvaChandelier"));
                recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 4);
                recipe.AddTile(ModContent.TileType<AuricManufacturerPlaced>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
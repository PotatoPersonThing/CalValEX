using Terraria.ModLoader;
using CalValEX.Tiles.Cages;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Cages
{
    public class ViolemurMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Violemur Perch");
            Item.ResearchUnlockCount = 1;
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
            Item.createTile = ModContent.TileType<ViolemurMonolithPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.LightRed;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<ViolemurItem>());
                recipe.AddIngredient(ModContent.ItemType<MonolithPot>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
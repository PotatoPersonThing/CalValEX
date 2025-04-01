using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class GoldEyedolTerrarium : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gold Eyedol Cage");
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
            Item.createTile = ModContent.TileType<GoldEyedolTerrariumPlaced>();
            Item.width = 32;
            Item.height = 28;
            Item.rare = ItemRarityID.Orange;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<GoldEyedolItem>());
                recipe.AddIngredient((ItemID.Terrarium), 1);
                recipe.AddIngredient(ItemID.IronBar, 3);
                recipe.anyIronBar = true;
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
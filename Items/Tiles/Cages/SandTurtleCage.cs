using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class SandTurtleCage : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sand Turtle Cage");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<SandTurtleCagePlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 0, 10, 0);
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<SandTurtleItem>());
                recipe.AddIngredient((ItemID.Terrarium), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
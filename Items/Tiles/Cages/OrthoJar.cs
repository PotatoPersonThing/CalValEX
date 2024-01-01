using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Tiles.Cages;

namespace CalValEX.Items.Tiles.Cages
{
    public class OrthoJar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orthocera in a Jar");
            Item.ResearchUnlockCount = 1;
        }

        // The tooltip for this item is automatically assigned from .lang files
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.createTile = TileType<OrthoJarPlaced>();
            Item.placeStyle = 0;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<OrthobabItem>());
                recipe.AddIngredient((ItemID.Bottle), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Tiles.FurnitureSets.Phantowax;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
    public class PhantowaxCandelabraItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantowax Candelabra");
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
            Item.createTile = ModContent.TileType<PhantowaxCandelabra>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 0;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm"), 3);
                recipe.AddIngredient(ModContent.ItemType<PhantowaxBlock>(), 5);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
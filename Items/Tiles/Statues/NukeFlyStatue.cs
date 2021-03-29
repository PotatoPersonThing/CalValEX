using CalValEX.Items.Critters;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Tiles.Statues
{
    public class NukeFlyStatue : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vaporofly Statue");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ArmorStatue);
            item.createTile = TileType<NukeFlyStatuePlaced>();
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<NukeFlyItem>(), 5);
                recipe.AddIngredient((ItemID.StoneBlock), 50);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
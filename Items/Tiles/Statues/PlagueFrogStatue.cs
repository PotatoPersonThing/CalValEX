using CalValEX.Items.Critters;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Tiles.Statues
{
    public class PlagueFrogStatue : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Frog Statue");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ArmorStatue);
            item.createTile = TileType<PlagueFrogStatuePlaced>();
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<PlagueFrogItem>(), 5);
                recipe.AddIngredient((ItemID.StoneBlock), 50);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
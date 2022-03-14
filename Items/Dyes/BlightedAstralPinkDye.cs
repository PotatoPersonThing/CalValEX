using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Dyes
{
    public class BlightedAstralPinkDye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blighted Astral Pink Dye");
            Tooltip.SetDefault("Unobtainable");
        }

        public override void SetDefaults()
        {
            byte dye = item.dye;
            item.CloneDefaults(ItemID.GelDye);
            item.width = 22;
            item.height = 26;
            item.value = Item.sellPrice(0, 0, 0, 5);
            item.dye = dye;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Tiles.Blocks.BlightedEggBlock>(), 3);
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }*/
    }
}
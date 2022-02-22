using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Dyes
{
    public class BlightedAstralDye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ethereal Dye");
        }

        public override void SetDefaults()
        {
            byte dye = item.dye;
            item.CloneDefaults(ItemID.GelDye);
            item.width = 22;
            item.height = 26;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.dye = dye;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("TwistingNether"), 1);
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }
    }
}
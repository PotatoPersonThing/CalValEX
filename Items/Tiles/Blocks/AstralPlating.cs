using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;
using CalValEX.Items.Walls;
using CalValEX.Items.Tiles.FurnitureSets.Auric;

namespace CalValEX.Items.Tiles.Blocks
{
    public class AstralPlating : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.rare = 0;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<AstralPlatingPlaced>();
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient((ItemID.StoneBlock), 120);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralJelly"), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
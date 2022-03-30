using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.AstralBlocks;

namespace CalValEX.Items.Tiles.Blocks.Astral
{
    public class AstralSand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blighted Astral Sand");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AstralSandPlaced>();
        }

        /*
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralSand"));
                recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
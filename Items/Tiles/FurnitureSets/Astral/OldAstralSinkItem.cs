using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Astral;
using CalValEX.Items.Tiles.Blocks.Astral;

namespace CalValEX.Items.Tiles.FurnitureSets.Astral
{
    public class OldAstralSinkItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomonolith Sink");
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
            Item.createTile = ModContent.TileType<OldAstralSink>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 0;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.EmptyBucket), 1);
                recipe.AddIngredient(ModContent.ItemType<AstralTreeWood>(), 6);
                recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe.SetResult(this);
                recipe.AddRecipe();

                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MonolithSink"));
                recipe2.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }*/
    }
}
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Astral;
using CalValEX.Items.Tiles.Blocks.Astral;

namespace CalValEX.Items.Tiles.FurnitureSets.Astral
{
    public class OldAstralChestItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomonolith Chest");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 500;
            Item.createTile = ModContent.TileType<OldAstralChest>();
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AstralTreeWood>(), 15);
            recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MonolithChest"));
            recipe2.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }*/
    }
}
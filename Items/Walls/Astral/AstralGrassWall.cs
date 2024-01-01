using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Walls.AstralSafe;

namespace CalValEX.Items.Walls.Astral
{
    public class AstralGrassWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blighted Astral Grass Wall");
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.rare = ItemRarityID.White;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<AstralGrassWallPlaced>();
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralGrassWall"));
            recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
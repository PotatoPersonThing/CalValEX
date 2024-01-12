using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Walls.AstralSafe;

namespace CalValEX.Items.Walls.Astral
{
    public class AstralIceWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blighted Astral Ice Wall");
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<AstralIceWallSafePlaced>();
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AstralIce>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralIceWall"));
            recipe2.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }*/
    }
}
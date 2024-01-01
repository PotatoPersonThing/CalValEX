using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Walls
{
    public class MossyGravelWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Compensation");
            // Tooltip.SetDefault("Can be sold");
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.rare = ItemRarityID.White;
            Item.value = 1;
            //Item.useTurn = true;
           // Item.autoReuse = true;
            //Item.useAnimation = 15;
            //Item.useTime = 7;
            //Item.useStyle = ItemUseStyleID.Swing;
            //Item.consumable = true;
            //Item.createWall = ModContent.WallType<MossyGravelWallPlaced>();
        }

        /*/*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AbyssGravelWallItem"), 4);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PlantyMush"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }*/
    }
}
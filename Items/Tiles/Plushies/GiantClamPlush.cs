using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Plushies;

namespace CalValEX.Items.Tiles.Plushies
{
    public class GiantClamPlush : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Giant Clam Plushie (Placeable)");
            // Tooltip.SetDefault("Master drop");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.LightRed;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.createTile = ModContent.TileType<ClamPlushPlaced>();
            Item.maxStack = 99;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<GiantClamPlushThrowable>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Plushies;

namespace CalValEX.Items.Tiles.Plushies
{
    public class AquaticScourgePlush : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Scourge Plushie (Placeable)");
            Tooltip.SetDefault("Master drop");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 4;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.createTile = ModContent.TileType<AquaticScourgePlushPlaced>();
            Item.maxStack = 99;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<AquaticScourgePlushThrowable>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}
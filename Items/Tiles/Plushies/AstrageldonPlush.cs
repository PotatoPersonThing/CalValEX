using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Plushies;

namespace CalValEX.Items.Tiles.Plushies
{
    public class AstrageldonPlush : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrageldon Plushie (Placeable)");
            Tooltip.SetDefault("Master drop");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 10;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.createTile = ModContent.TileType<AstrageldonPlushPlaced>();
            Item.maxStack = 99;
        }

        /*public override void AddRecipes()
        {
            Mod Cata = ModLoader.GetMod("CatalystMod");
            if (Cata != null)
            {
                Mod CalValEX = ModLoader.GetMod("CalamityMod");
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ModContent.ItemType<AstrageldonPlushThrowable>());
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
            }
        }*/
    }
}
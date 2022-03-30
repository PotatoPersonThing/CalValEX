using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Plants
{
    public class AcidGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Tape Dispenser");
            Tooltip.SetDefault("Places an infinite amount of Sulphurous Vines");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 4;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.width = 16;
            Item.height = 28;
            Item.rare = 4;
            /*Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                Item.createTile = (calamityMod.TileType("SulphurousVines"));
            }*/
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SulfuricScale"), 5);
                recipe.AddIngredient((ItemID.VineRope), 50);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}